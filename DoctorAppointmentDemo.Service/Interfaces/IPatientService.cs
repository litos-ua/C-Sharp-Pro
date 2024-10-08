using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace MyDoctorAppointment.Service.Interfaces
//{
//    public interface IPatientService
//    {
//        Patient Create(Patient patient);

//        IEnumerable<Patient> GetAll();

//        Patient? Get(int id);

//        bool Delete(int id);

//        Patient Update(int id, Patient patient);
//    }
//}

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IPatientService
    {

        Patient CreatePatient(string name, string surname, string phone, string email, IllnessTypes illnessType);

        IEnumerable<Patient> GetAll();

        Patient? Get(int id);

        bool Delete(int id);

        Patient Update(int id, Patient patient);
    }
}

