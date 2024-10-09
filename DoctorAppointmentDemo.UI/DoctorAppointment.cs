using MyDoctorAppointment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly PatientManager _patientManager;
        private readonly DoctorManager _doctorManager;
        private readonly AppointmentManager _appointmentManager;

        public DoctorAppointment(IDoctorService doctorService, IPatientService patientService, IAppointmentService appointmentService)
        {
            _doctorManager = new DoctorManager(doctorService);
            _patientManager = new PatientManager(patientService);
            _appointmentManager = new AppointmentManager(appointmentService, patientService, doctorService);
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

