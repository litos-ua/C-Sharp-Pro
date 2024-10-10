﻿using System;
using System.Collections.Generic;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository(); 
        }


        public Appointment Create(Patient patient, Doctor doctor, DateTime startDateTime, DateTime endDateTime, string description)
        {
            var newAppointment = new Appointment
            {
                Patient = patient,
                Doctor = doctor,
                DateTimeFrom = startDateTime,
                DateTimeTo = endDateTime,
                Description = description
            };

            return _appointmentRepository.Create(newAppointment);
        }


        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }

        void IAppointmentService.Create(Patient patient, Doctor doctor, DateTime startDateTime, DateTime endDateTime, string? description)
        {
            throw new NotImplementedException();
        }
    }
}
