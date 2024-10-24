
namespace DoctorAppointmentDemo.Domain.Entities.Interfaces
{
    public interface IEntityCollection<T>
    {
        List<T> Items { get; set; }
    }
}
