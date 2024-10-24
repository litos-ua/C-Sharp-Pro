
using MyDoctorAppointment.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface IDataSerializerService
    {
        void Serialize<T>(T data, string filePath);
        T Deserialize<T>(string filePath);
    }
}


