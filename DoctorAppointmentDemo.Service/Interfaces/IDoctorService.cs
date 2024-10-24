using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IDoctorService : IGenericService <Doctor>
    {
        Doctor Create(string name, string surname, DoctorTypes doctorType, byte experience);
    }
}
