
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        void Create(Patient patient, Doctor doctor, DateTime startDateTime, DateTime endDateTime, string? description);
    }
}