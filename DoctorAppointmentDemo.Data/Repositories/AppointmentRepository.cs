

using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using System.Linq;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }
        public override string DataFormat { get; set; }

        public AppointmentRepository(IDataSerializerService appointmentSerializer, string dataFormat)
            : base(appointmentSerializer)
        {
            DataFormat = dataFormat;
            var config = ReadFromAppSettings();
            Path = PathHelper.GetDatabaseFilePath(config.Database.Appointments.Path);
            LastId = config.Database.Appointments.LastId;
        }


        public override Appointment Create(Appointment source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            if (!File.Exists(Path))
            {
                if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
                {
                    var emptyCollection = CreateCollection(new List<Appointment>());
                    _dataSerializer.Serialize(emptyCollection, Path);
                }
                else
                {
                    // For JSON
                    _dataSerializer.Serialize(new List<Appointment>(), Path);
                }
            }

            // Get the current data and append
            var data = GetAll().Append(source);

            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {

                try
                {
                    // Explicit cast to PatientsCollection
                    var collection = CreateCollection(data) as AppointmentsCollection;

                    if (collection != null && collection.Appointments != null)
                    {
                        _dataSerializer.Serialize(collection, Path);
                        Console.WriteLine("Сериализация завершена успешно");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: коллекция не содержит пациентов.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при сериализации: {ex.Message}");
                    throw;
                }

            }
            else
            {
                // For JSON
                _dataSerializer.Serialize(data, Path);
            }

            SaveLastId();  

            return source;
        }

        protected override object CreateCollection(IEnumerable<Appointment> data)
        {
            return new AppointmentsCollection { Appointments = data.ToList() };
        }

        
        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Appointments.LastId = LastId;

            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(DataFormat));
            File.WriteAllText(appSettingsPath, result.ToString());  
        }
    }
}

