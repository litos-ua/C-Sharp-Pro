using DoctorAppointmentDemo.UI.Enums;
using MyDoctorAppointment;

namespace DoctorAppointmentDemo.UI
{
    public class MenuManager
    {
        public void DisplayMenu(DoctorManager doctorManager, PatientManager patientManager, AppointmentManager appointmentManager)
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

                if (Enum.TryParse(choice, out MenuAction action))
                {
                    HandleMenuAction(action, doctorManager, patientManager, appointmentManager, ref exit);
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

        private void HandleMenuAction(MenuAction action, DoctorManager doctorManager, PatientManager patientManager, AppointmentManager appointmentManager, ref bool exit)
        {
            switch (action)
            {
                case MenuAction.ViewDoctors:
                    doctorManager.ViewDoctors();
                    break;
                case MenuAction.ViewPatients:
                    patientManager.ViewPatients();
                    break;
                case MenuAction.ViewAppointments:
                    appointmentManager.ViewAppointments();
                    break;
                case MenuAction.AddDoctor:
                    doctorManager.AddDoctor();
                    break;
                case MenuAction.AddPatient:
                    patientManager.AddPatient();
                    break;
                case MenuAction.AddAppointment:
                    appointmentManager.AddAppointment();
                    break;
                case MenuAction.Exit:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
