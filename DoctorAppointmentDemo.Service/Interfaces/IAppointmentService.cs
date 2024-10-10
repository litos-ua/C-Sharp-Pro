//using MyDoctorAppointment.Domain.Entities;

//namespace MyDoctorAppointment.Service.Interfaces
//{
//    public interface IAppointmentService
//    {
//        Appointment Create(Appointment appointment);

//        IEnumerable<Appointment> GetAll();

//        Appointment? Get(int id);

//        bool Delete(int id);

//        Appointment Update(int id, Appointment appointment);
//    }
//}

using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    //public interface IAppointmentService : IGenericService<Appointment>
    //{
    //    // To develop specific methods for to AppointmentService here.
    //}
    public interface IAppointmentService : IGenericService<Appointment>
    {
        // To develop specific methods for to AppointmentService here.
        void Create(Patient patient, Doctor doctor, DateTime startDateTime, DateTime endDateTime, string? description);
    }
}