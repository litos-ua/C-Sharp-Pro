

using DoctorAppointmentDemo.Service.Services.Data;
using MyDoctorAppointment.Data.Repositories;
using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Service.Services;
using DoctorAppointmentDemo.UI.Enums;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {

        private PatientManager _patientManager;
        private DoctorManager _doctorManager;
        private AppointmentManager _appointmentManager;
        public string? DataFormat = "JSON";


        public DoctorAppointment(DoctorManager doctorManager, PatientManager patientManager, AppointmentManager appointmentManager)
        {
            _doctorManager = doctorManager ?? throw new ArgumentNullException(nameof(doctorManager));
            _patientManager = patientManager ?? throw new ArgumentNullException(nameof(patientManager));
            _appointmentManager = appointmentManager ?? throw new ArgumentNullException(nameof(appointmentManager));
        }

        //Generate to fix the error
        public DoctorAppointment(DoctorService doctorService, PatientService patientService, AppointmentService appointmentService)
        {
        }

        public void Run()
        {
            bool exit = false;

            Console.WriteLine("Select data storage type: 1 - JSON, 2 - XML");
            string dataChoice = Console.ReadLine();

            // Set up serializers for doctor, patient, and appointment data
            IDataSerializerService doctorSerializer = null;
            IDataSerializerService patientSerializer = null;
            IDataSerializerService appointmentSerializer = null;

            DataFormatEnum chosenFormat;

            if (Enum.TryParse(dataChoice, out chosenFormat) && Enum.IsDefined(typeof(DataFormatEnum), chosenFormat))
            {
                switch (chosenFormat)
                {
                    case DataFormatEnum.JSON:
                        doctorSerializer = new JsonDataSerializerService();
                        patientSerializer = new JsonDataSerializerService();
                        appointmentSerializer = new JsonDataSerializerService();
                        this.DataFormat = "JSON";
                        break;

                    case DataFormatEnum.XML:
                        doctorSerializer = new XmlDataSerializerService();
                        patientSerializer = new XmlDataSerializerService();
                        appointmentSerializer = new XmlDataSerializerService();
                        this.DataFormat = "XML";
                        break;
                }
            }
            else
            {
                // if data not from enum use JSON
                doctorSerializer = new JsonDataSerializerService();
                patientSerializer = new JsonDataSerializerService();
                appointmentSerializer = new JsonDataSerializerService();
                this.DataFormat = "JSON";
                Console.WriteLine("Invalid option. Defaulting to JSON format.");
            }

            // Pass the chosen serializer to the repositories
            var doctorRepository = new DoctorRepository(doctorSerializer, this.DataFormat);
            var patientRepository = new PatientRepository(patientSerializer, this.DataFormat);
            var appointmentRepository = new AppointmentRepository(appointmentSerializer, this.DataFormat);

            // Initialize managers with the appropriate services/repositories
            _doctorManager = new DoctorManager(new DoctorService(doctorRepository));
            _patientManager = new PatientManager(new PatientService(patientRepository));
            _appointmentManager = new AppointmentManager(
                new AppointmentService(appointmentRepository, patientRepository, doctorRepository),
                new PatientService(patientRepository),
                new DoctorService(doctorRepository)
            );

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Doctor Appointment Management System");
                Console.WriteLine("1. View Doctors");
                Console.WriteLine("2. View Patients");
                Console.WriteLine("3. View Appointments");
                Console.WriteLine("4. Add Doctor");
                Console.WriteLine("5. Add Patient");
                Console.WriteLine("6. Add Appointment");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                if (Enum.TryParse(choice, out MenuAction action))
                {
                    switch (action)
                    {
                        case MenuAction.ViewDoctors:
                            _doctorManager.ViewDoctors();
                            break;
                        case MenuAction.ViewPatients:
                            _patientManager.ViewPatients();
                            break;
                        case MenuAction.ViewAppointments:
                            _appointmentManager.ViewAppointments();
                            break;
                        case MenuAction.AddDoctor:
                            _doctorManager.AddDoctor();
                            break;
                        case MenuAction.AddPatient:
                            _patientManager.AddPatient();
                            break;
                        case MenuAction.AddAppointment:
                            _appointmentManager.AddAppointment();
                            break;
                        case MenuAction.Exit:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter a number.");
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }

    }
}