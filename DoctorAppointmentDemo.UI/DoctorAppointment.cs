
using DoctorAppointmentDemo.Service.Services.Data;
using DoctorAppointmentDemo.Service.Services;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        //private readonly PatientManager _patientManager;
        //private readonly DoctorManager _doctorManager;
        //private readonly AppointmentManager _appointmentManager;

        private PatientManager _patientManager;
        private DoctorManager _doctorManager;
        private AppointmentManager _appointmentManager;

        //public DoctorAppointment(IDoctorService doctorService, IPatientService patientService, IAppointmentService appointmentService)
        //{
        //    _doctorManager = new DoctorManager(doctorService);
        //    _patientManager = new PatientManager(patientService);
        //    _appointmentManager = new AppointmentManager(appointmentService, patientService, doctorService);
        //}

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
            IDataSerializerService doctorSerializer;
            IDataSerializerService patientSerializer;
            IDataSerializerService appointmentSerializer;

            switch (dataChoice)
            {
                case "1":
                    doctorSerializer = new JsonDataSerializerService();
                    patientSerializer = new JsonDataSerializerService();
                    appointmentSerializer = new JsonDataSerializerService();
                    break;
                case "2":
                    doctorSerializer = new XmlDataSerializerService();
                    patientSerializer = new XmlDataSerializerService();                                                            
                    appointmentSerializer = new XmlDataSerializerService();
                    break;
                default:
                    doctorSerializer = new JsonDataSerializerService();
                    patientSerializer = new JsonDataSerializerService();
                    appointmentSerializer = new JsonDataSerializerService();
                    Console.WriteLine("By default, data is saved in the JSON format.");
                    break;
            }

            // Pass the chosen serializer to the repositories
            var doctorRepository = new DoctorRepository(doctorSerializer);
            var patientRepository = new PatientRepository(patientSerializer);
            var appointmentRepository = new AppointmentRepository(appointmentSerializer);

            // Initialize managers with the appropriate services/repositories
            _doctorManager = new DoctorManager(new DoctorService(doctorRepository));
            _patientManager = new PatientManager(new PatientService(patientRepository));
            //_appointmentManager = new AppointmentManager(new AppointmentService(appointmentRepository, patientRepository, doctorRepository));
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
                switch (choice)
                {
                    case "1":
                        _doctorManager.ViewDoctors();
                        break;
                    case "2":
                        _patientManager.ViewPatients();
                        break;
                    case "3":
                        _appointmentManager.ViewAppointments();
                        break;
                    case "4":
                        _doctorManager.AddDoctor();
                        break;
                    case "5":
                        _patientManager.AddPatient();
                        break;
                    case "6":
                        _appointmentManager.AddAppointment();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
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
