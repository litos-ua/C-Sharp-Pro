using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;

        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
        }

        public void Menu()
        {
            //while (true)
            //{
            //    // add Enum for menu items and describe menu
            //}

            Console.WriteLine("Current doctors list: ");
            var docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Name);
            }

            Console.WriteLine("Adding doctor: ");

            var newDoctor = new Doctor
            {
                Name = "Vasya",
                Surname = "Petrov",
                Experience = 20,
                DoctorType = Domain.Enums.DoctorTypes.Dentist
            };

            _doctorService.Create(newDoctor);

            Console.WriteLine("Current doctors list: ");
            docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Name);
            }
        }
    }



    public static class Program
    {
        public static void Main()
        {
            // Создаем экземпляр DoctorService
            var doctorService = new DoctorService();

            // Заполняем данные нового доктора
            var newDoctor = new Doctor
            {
                Name = "Julia",
                Surname = "Krasnowska",
                Experience = 3,
                DoctorType = Domain.Enums.DoctorTypes.FamilyDoctor,
                Salary = 2500.0m
            };

            // Добавляем нового доктора с помощью метода Create()
            doctorService.Create(newDoctor);

            Console.WriteLine("Doctor added successfully!");



            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();

        }
    }
}