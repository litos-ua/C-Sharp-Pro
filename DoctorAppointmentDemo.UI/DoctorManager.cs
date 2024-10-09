using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment
{
    public class DoctorManager
    {
        private readonly IDoctorService _doctorService;

        public DoctorManager(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public void ViewDoctors()
        {
            var doctors = _doctorService.GetAll();
            Console.WriteLine("Doctors List:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{doctor.Id}. {doctor.Name} {doctor.Surname}");
            }
        }

        public void AddDoctor()
        {
            Console.WriteLine("Enter doctor's name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter doctor's surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter doctor's type (1 for Dentist, 2 for Dermatologist, etc.):");
            DoctorTypes doctorType = (DoctorTypes)int.Parse(Console.ReadLine());
            Console.WriteLine("Enter doctor's experience:");
            byte experience = byte.Parse(Console.ReadLine());

            _doctorService.Create(name, surname, doctorType, experience);
            Console.WriteLine("Doctor added successfully.");
        }

        public void EditDoctor()
        {
            // editing a doctor
        }

        public void DeleteDoctor()
        {
            Console.WriteLine("Enter doctor's ID to delete:");
            int id = int.Parse(Console.ReadLine());
            bool isDeleted = _doctorService.Delete(id);

            if (isDeleted)
                Console.WriteLine("Doctor deleted successfully.");
            else
                Console.WriteLine("Doctor not found.");
        }
    }
}


