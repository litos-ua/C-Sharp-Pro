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