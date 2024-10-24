

using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository 
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }
        public override string DataFormat { get; set; }

        public DoctorRepository(IDataSerializerService doctorSerializer, string dataFormat)
            : base(doctorSerializer)
        {
            DataFormat = dataFormat;  
            var config = ReadFromAppSettings();
            Path = PathHelper.GetDatabaseFilePath(config.Database.Doctors.Path);
            LastId = config.Database.Doctors.LastId;
        }

        public override Doctor Create(Doctor source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            if (!File.Exists(Path))
            {
                if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
                {
                    var emptyCollection = CreateCollection(new List<Doctor>());
                    _dataSerializer.Serialize(emptyCollection, Path);
                }
                else
                {
                    // For JSON
                    _dataSerializer.Serialize(new List<Doctor>(), Path);
                }
            }

            // Get the current data and append
            var data = GetAll().Append(source);

            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {

                try
                {
                    // Explicit cast to PatientsCollection
                    var collection = CreateCollection(data) as DoctorsCollection;

                    if (collection != null && collection.Doctors != null)
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


        public override IEnumerable<Doctor> GetAll()
        {
            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {
                // Если формат XML, десериализуем коллекцию докторов из XML
                var doctorsCollection = _dataSerializer.Deserialize<DoctorsCollection>(Path);
                return doctorsCollection?.Doctors ?? new List<Doctor>();
            }
            else
            {
                return base.GetAll();
            }
        }

        protected override object CreateCollection(IEnumerable<Doctor> data)
        {
            // Create collection to  XML serialization
            return new DoctorsCollection { Doctors = data.ToList() };
        }

        protected override void SaveLastId()
        {
            var config = ReadFromAppSettings();
            config.Database.Patients.LastId = LastId;

            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(DataFormat));
            File.WriteAllText(appSettingsPath, JsonConvert.SerializeObject(config, Formatting.Indented));
        }
    }
}



