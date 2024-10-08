using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IDoctorService
    {
        //Doctor Create(Doctor doctor);
        Doctor Create(string name, string surname, DoctorTypes doctorType, byte experience);

        IEnumerable<Doctor> GetAll();

        Doctor? Get(int id);

        bool Delete(int id);

        Doctor Update(int id, Doctor doctor);
    }
}
