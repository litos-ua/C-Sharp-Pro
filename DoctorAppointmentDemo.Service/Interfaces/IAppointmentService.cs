
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        // To develop specific methods for to AppointmentService here.
        void Create(Patient patient, Doctor doctor, DateTime startDateTime, DateTime endDateTime, string? description);
    }
}