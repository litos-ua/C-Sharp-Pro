

using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Data.Interfaces;
using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }
        public override string DataFormat { get; set; }

        public PatientRepository(IDataSerializerService patientSerializer, string dataFormat)
            : base(patientSerializer)
        {
            DataFormat = dataFormat;
            var config = ReadFromAppSettings();
            Path = PathHelper.GetDatabaseFilePath(config.Database.Patients.Path);
            LastId = config.Database.Patients.LastId;
        }


        public override Patient Create(Patient source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            if (!File.Exists(Path))
            {
                if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
                {
                    var emptyCollection = CreateCollection(new List<Patient>());
                    _dataSerializer.Serialize(emptyCollection, Path);
                }
                else
                {
                    // For JSON
                    _dataSerializer.Serialize(new List<Patient>(), Path);
                }
            }

            // Get the current data and append the new source
            var data = GetAll().Append(source);

            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {

                try
                {
                    // Explicit cast to PatientsCollection
                    var collection = CreateCollection(data) as PatientsCollection;

                    if (collection != null && collection.Patients != null)
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
                // For JSON, serialize the list
                _dataSerializer.Serialize(data, Path);
            }

            SaveLastId();  

            return source;
        }

        public override IEnumerable<Patient> GetAll()
        {
            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {
                // Deserializing a Patient Collection from XML
                var patientsCollection = _dataSerializer.Deserialize<PatientsCollection>(Path);
                return patientsCollection?.Patients ?? new List<Patient>();
            }
            else
            {
                return base.GetAll();
            }
        }

        protected override object CreateCollection(IEnumerable<Patient> data)
        {
            // Create collection to  XML serialization
            return new PatientsCollection { Patients = data.ToList() };
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


