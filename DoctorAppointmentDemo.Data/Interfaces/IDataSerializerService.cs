//using MyDoctorAppointment.Domain.Entities;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public interface IDataSerializerService<T>
//    {
//        void Serialize(IEnumerable<T> data, string filePath);
//        IEnumerable<T> Deserialize(string filePath);
//    }
//}

using MyDoctorAppointment.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface IDataSerializerService
    {
        void Serialize<T>(T data, string filePath);
        T Deserialize<T>(string filePath);
    }
}
