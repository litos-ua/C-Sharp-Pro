using System;
using System.Collections.Generic;

using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService()
        {
            _patientRepository = new PatientRepository(); 
        }


        public Patient CreatePatient(string name, string surname, string phone, string email, IllnessTypes illnessType)
        {
            var newPatient = new Patient
            {
                Name = name,
                Surname = surname,
                Phone = phone,
                Email = email,
                IllnessType = illnessType
            };

            return _patientRepository.Create(newPatient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public Patient? Get(int id)
        {
            return _patientRepository.GetById(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient Update(int id, Patient patient)
        {
            return _patientRepository.Update(id, patient);
        }
    }
}

