using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

//namespace MyDoctorAppointment
//{
//    public class DoctorAppointment
//    {
//        private readonly IDoctorService _doctorService;

//        private readonly IPatientService _patientService;


//        public DoctorAppointment()
//        {
//            _doctorService = new DoctorService();
//            _patientService = new PatientService();
//        }

//        public void Menu()
//        {
//            //while (true)
//            //{
//            //    // add Enum for menu items and describe menu
//            //}

//            Console.WriteLine("Current doctors list: ");
//            var docs = _doctorService.GetAll();

//            foreach (var doc in docs)
//            {
//                Console.WriteLine(doc.Name);
//            }

//            //Console.WriteLine("Adding doctor: ");

//            //var newDoctor = new Doctor
//            //{
//            //    Name = "Vasya",
//            //    Surname = "Petrov",
//            //    Experience = 20,
//            //    DoctorType = Domain.Enums.DoctorTypes.Dentist
//            //};

//            //_doctorService.Create(newDoctor);


//            var patientService = new PatientService();

//            Console.WriteLine("Adding patient: ");
//            var newPatient = new Patient
//            {
//                Name = "Sergiy",
//                Surname = "Jarmolenko",
//                Phone = "333-77-111",
//                Email = "syarm@gmail.com",
//                IllnessType = IllnessTypes.Infection,
//            };


//            try
//            {
//                patientService.Create(newPatient);
//                Console.WriteLine("Patient added successfully!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Patient don't created: {ex.Message}");
//            }


//            Console.WriteLine("Current patient list: ");
//            docs = _doctorService.GetAll();

//            foreach (var doc in docs)
//            {
//                Console.WriteLine(doc.Name);
//            }
//        }
//    }



//    public static class Program
//    {
//        public static void Main()
//        {
//            //var doctorService = new DoctorService();

//            //Console.WriteLine("Adding doctor: ");
//            //var newDoctor = new Doctor
//            //{
//            //    Name = "Julia",
//            //    Surname = "Krasnowska",
//            //    Experience = 3,
//            //    DoctorType = Domain.Enums.DoctorTypes.FamilyDoctor,
//            //    Salary = 2500.0m
//            //};


//            //try
//            //{
//            //    doctorService.Create(newDoctor);
//            //    Console.WriteLine("Doctor added successfully!");
//            //}
//            //catch (Exception ex)
//            //{
//            //    Console.WriteLine($"Doctor don't created: {ex.Message}");
//            //}



//            var doctorAppointment = new DoctorAppointment();
//            doctorAppointment.Menu();

//        }
//    }
//}

using System;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public DoctorAppointment(IDoctorService doctorService, IPatientService patientService, IAppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _patientService = patientService;
            _appointmentService = appointmentService;
        }

        public void Run()
        {
            bool exit = false;
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
                Console.WriteLine("7. Edit Doctor");
                Console.WriteLine("8. Edit Patient");
                Console.WriteLine("9. Edit Appointment");
                Console.WriteLine("10. Delete Doctor");
                Console.WriteLine("11. Delete Patient");
                Console.WriteLine("12. Delete Appointment");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewDoctors();
                        break;
                    case "2":
                        ViewPatients();
                        break;
                    case "3":
                        ViewAppointments();
                        break;
                    case "4":
                        AddDoctor();
                        break;
                    case "5":
                        AddPatient();
                        break;
                    case "6":
                        AddAppointment();
                        break;
                    case "7":
                        EditDoctor();
                        break;
                    case "8":
                        EditPatient();
                        break;
                    case "9":
                        EditAppointment();
                        break;
                    case "10":
                        DeleteDoctor();
                        break;
                    case "11":
                        DeletePatient();
                        break;
                    case "12":
                        DeleteAppointment();
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

        private void ViewDoctors()
        {
            var doctors = _doctorService.GetAll();
            Console.WriteLine("Doctors List:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{doctor.Id}. {doctor.Name} {doctor.Surname}");
            }
        }

        private void ViewPatients()
        {
            var patients = _patientService.GetAll();
            Console.WriteLine("Patients List:");
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Id}. {patient.Name} {patient.Surname}");
            }
        }

        private void ViewAppointments()
        {
            var appointments = _appointmentService.GetAll();
            Console.WriteLine("Appointments List:");
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"{appointment.Id}. Doctor: {appointment.Doctor.Name}, Patient: {appointment.Patient.Name}, Date: {appointment.DateTimeFrom}");
            }
        }

        private void AddDoctor()
        {
            Console.WriteLine("Enter doctor's name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter doctor's surname:");
            string surname = Console.ReadLine();
            // Add more fields as necessary...
            var newDoctor = new Doctor { Name = name, Surname = surname };
            _doctorService.Create(newDoctor);
            Console.WriteLine("Doctor added successfully.");
        }

        // Implement similar methods for adding/editing/deleting patients and appointments...

        private void AddPatient()
        {
            // Similar logic for adding a patient
        }

        private void AddAppointment()
        {
            // Similar logic for adding an appointment
        }

        private void EditDoctor()
        {
            // Similar logic for editing a doctor
        }

        private void EditPatient()
        {
            // Similar logic for editing a patient
        }

        private void EditAppointment()
        {
            // Similar logic for editing an appointment
        }

        private void DeleteDoctor()
        {
            // Similar logic for deleting a doctor
        }

        private void DeletePatient()
        {
            // Similar logic for deleting a patient
        }

        private void DeleteAppointment()
        {
            // Similar logic for deleting an appointment
        }
    }

    public static class Program
    {
        public static void Main()
        {
            var doctorService = new DoctorService();
            var patientService = new PatientService();
            var appointmentService = new AppointmentService();
            var app = new DoctorAppointment(doctorService, patientService, appointmentService);
            app.Run();
        }
    }
}
