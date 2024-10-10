﻿//using MyDoctorAppointment.Domain.Entities;
//using MyDoctorAppointment.Domain.Enums;

//namespace MyDoctorAppointment.Service.Interfaces
//{
//    public interface IPatientService
//    {

//        Patient CreatePatient(string name, string surname, string phone, string email, IllnessTypes illnessType);

//        IEnumerable<Patient> GetAll();

//        Patient? Get(int id);

//        bool Delete(int id);

//        Patient Update(int id, Patient patient);
//    }
//}

using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IPatientService : IGenericService<Patient>
    {
        Patient CreatePatient(string name, string surname, string phone, string email, IllnessTypes illnessType);

        // To develop specific methods for to AppointmentService here.
    }
}