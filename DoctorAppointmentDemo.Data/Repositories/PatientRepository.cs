
//using MyDoctorAppointment.Data.Configuration;
//using MyDoctorAppointment.Domain.Entities;
//using MyDoctorAppointment.Data.Interfaces;
//using DoctorAppointmentDemo.Data.Interfaces;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
//    {
//        public override string Path { get; set; }
//        public override int LastId { get; set; }

//        public override string DataFormat { get; set; }

//        public PatientRepository(IDataSerializerService patientSerializer, string dataFormat)
//            : base(patientSerializer)
//        {

//            var config = ReadFromAppSettings();
//            Path = PathHelper.GetDatabaseFilePath(config.Database.Patients.Path);
//            LastId = config.Database.Patients.LastId;
//            DataFormat = dataFormat;
//        }

//        public override void ShowInfo(Patient patient)
//        {
//            Console.WriteLine($"{patient.Name} {patient.Surname} - {patient.IllnessType}");
//        }

//        protected override void SaveLastId()
//        {
//            dynamic result = ReadFromAppSettings();
//            result.Database.Patients.LastId = LastId;

//            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(this.DataFormat));
//            File.WriteAllText(appSettingsPath, result.ToString());  
//        }
//    }
//}


//using MyDoctorAppointment.Data.Configuration;
//using MyDoctorAppointment.Domain.Entities;
//using MyDoctorAppointment.Data.Interfaces;
//using DoctorAppointmentDemo.Data.Interfaces;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
//    {
//        public override string Path { get; set; }
//        public override int LastId { get; set; }

//        public override string DataFormat { get; set; }

//        public PatientRepository(IDataSerializerService patientSerializer, string dataFormat)
//            : base(patientSerializer)
//        {

//            DataFormat = dataFormat;
//            var config = ReadFromAppSettings();
//            Path = PathHelper.GetDatabaseFilePath(config.Database.Patients.Path);
//            //Path = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(DataFormat));
//            LastId = config.Database.Patients.LastId;

//        }

//        public override IEnumerable<Patient> GetAll()
//        {
//            // Десериализация докторов из файла
//            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
//            {
//                // Используем _dataSerializer для десериализации
//                var patientsCollection = _dataSerializer.Deserialize<PatientsCollection>(Path);
//                return patientsCollection?.Patients ?? new List<Patient>();
//            }
//            else
//            {
//                return base.GetAll();
//            }
//        }

//        public override void ShowInfo(Patient patient)
//        {
//            Console.WriteLine($"{patient.Name} {patient.Surname} - {patient.IllnessType}");
//        }

//        protected override void SaveLastId()
//        {
//            dynamic result = ReadFromAppSettings();
//            result.Database.Patients.LastId = LastId;

//            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(DataFormat));
//            File.WriteAllText(appSettingsPath, result.ToString());
//        }
//    }
//}


///* Работает с json и как-то с xml (читает нормально, пишет с ошибкой)*/

//using MyDoctorAppointment.Data.Configuration;
//using MyDoctorAppointment.Domain.Entities;
//using MyDoctorAppointment.Data.Interfaces;
//using DoctorAppointmentDemo.Data.Interfaces;
//using Newtonsoft.Json;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
//    {
//        public override string Path { get; set; }
//        public override int LastId { get; set; }
//        public override string DataFormat { get; set; }

//        public PatientRepository(IDataSerializerService patientSerializer, string dataFormat)
//            : base(patientSerializer)
//        {
//            DataFormat = dataFormat;
//            var config = ReadFromAppSettings();
//            Path = PathHelper.GetDatabaseFilePath(config.Database.Patients.Path);
//            LastId = config.Database.Patients.LastId;
//        }

//        public override IEnumerable<Patient> GetAll()
//        {
//            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
//            {
//                var patientsCollection = _dataSerializer.Deserialize<PatientsCollection>(Path);
//                return patientsCollection?.Patients ?? new List<Patient>();
//            }
//            else
//            {
//                return base.GetAll();
//            }
//        }

//        protected override object CreateCollection(IEnumerable<Patient> data)
//        {
//            // Создаем коллекцию для XML сериализации
//            return new PatientsCollection { Patients = data.ToList() };
//        }

//        protected override void SaveLastId()
//        {
//            var config = ReadFromAppSettings();
//            config.Database.Patients.LastId = LastId;

//            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(DataFormat));
//            File.WriteAllText(appSettingsPath, JsonConvert.SerializeObject(config, Formatting.Indented));
//        }
//    }
//}
///*---------------------------------------------------------------------------------------------------------------*/


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

        public override IEnumerable<Patient> GetAll()
        {
            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {
                // Десериализация коллекции пациентов из XML
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
            // Создаем коллекцию для XML сериализации
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

