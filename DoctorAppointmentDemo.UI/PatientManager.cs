using System;
using System.Collections.Generic;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment
{
    public class PatientManager
    {
        private readonly IPatientService _patientService;

        public PatientManager(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public void ViewPatients()
        {
            var patients = _patientService.GetAll();
            Console.WriteLine("Patients List:");
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Id}. {patient.Name} {patient.Surname}");
            }
        }

        public void AddPatient()
        {
            Console.WriteLine("Enter patient's name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter patient's surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter patient's phone:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter patient's email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter patient's illness type (1 for EyeDisease, 2 for Infection, etc.):");
            int illnessTypeId = int.Parse(Console.ReadLine());

            var newPatient = _patientService.CreatePatient(name, surname, phone, email, (IllnessTypes)illnessTypeId);
            Console.WriteLine("Patient added successfully.");
        }

        private void EditPatient()
        {
            // To develop. 
        }

        private void DeletePatient()
        {
            Console.WriteLine("Enter patient's ID to delete:");
            int id = int.Parse(Console.ReadLine());
            bool isDeleted = _patientService.Delete(id);

            if (isDeleted)
                Console.WriteLine("Patient deleted successfully.");
            else
                Console.WriteLine("Patient not found.");
        }
    }
}

