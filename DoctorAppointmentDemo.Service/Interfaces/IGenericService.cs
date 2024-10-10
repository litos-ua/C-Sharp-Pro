using System.Collections.Generic;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IGenericService<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        bool Delete(int id);
        T Update(int id, T entity);
    }
}
