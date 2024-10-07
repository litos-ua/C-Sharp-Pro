using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;

        private readonly IPatientService _patientService;


        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
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

            //Console.WriteLine("Adding doctor: ");

            //var newDoctor = new Doctor
            //{
            //    Name = "Vasya",
            //    Surname = "Petrov",
            //    Experience = 20,
            //    DoctorType = Domain.Enums.DoctorTypes.Dentist
            //};

            //_doctorService.Create(newDoctor);


            var patientService = new PatientService();

            Console.WriteLine("Adding patient: ");
            var newPatient = new Patient
            {
                Name = "Sergiy",
                Surname = "Jarmolenko",
                Phone = "333-77-111",
                Email = "syarm@gmail.com",
                IllnessType = IllnessTypes.Infection,
            };


            try
            {
                patientService.Create(newPatient);
                Console.WriteLine("Patient added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Patient don't created: {ex.Message}");
            }


            Console.WriteLine("Current patient list: ");
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
            //var doctorService = new DoctorService();

            //Console.WriteLine("Adding doctor: ");
            //var newDoctor = new Doctor
            //{
            //    Name = "Julia",
            //    Surname = "Krasnowska",
            //    Experience = 3,
            //    DoctorType = Domain.Enums.DoctorTypes.FamilyDoctor,
            //    Salary = 2500.0m
            //};


            //try
            //{
            //    doctorService.Create(newDoctor);
            //    Console.WriteLine("Doctor added successfully!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Doctor don't created: {ex.Message}");
            //}



            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();

        }
    }
}