

//using DoctorAppointmentDemo.Data.Interfaces;
//using MyDoctorAppointment.Data.Configuration;
//using MyDoctorAppointment.Data.Interfaces;
//using MyDoctorAppointment.Domain.Entities;


//namespace MyDoctorAppointment.Data.Repositories
//{
//    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
//    {
//        public override string Path { get; set; }
//        public override int LastId { get; set; }
//        public override string DataFormat { get; set; }

//        public DoctorRepository(IDataSerializerService doctorSerializer, string dataFormat)
//            : base(doctorSerializer)
//        {
//            var config = ReadFromAppSettings();
//            Path = PathHelper.GetDatabaseFilePath(config.Database.Doctors.Path);
//            LastId = config.Database.Doctors.LastId;
//            DataFormat = dataFormat;
//        }

//        public override void ShowInfo(Doctor doctor)
//        {
//            Console.WriteLine($"Doctor: {doctor.Name} {doctor.Surname}, Type: {doctor.DoctorType}, Experience: {doctor.Experience} years");
//        }

//        protected override void SaveLastId()
//        {
//            dynamic result = ReadFromAppSettings();
//            result.Database.Doctors.LastId = LastId;

//            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(this.DataFormat));
//            File.WriteAllText(appSettingsPath, result.ToString());  // Save the updated last ID
//        }
//    }
//}

//using DoctorAppointmentDemo.Data.Interfaces;
//using MyDoctorAppointment.Data.Configuration;
//using MyDoctorAppointment.Data.Interfaces;
//using MyDoctorAppointment.Domain.Entities;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
//    {
//        public override string Path { get; set; }
//        public override int LastId { get; set; }
//        public override string DataFormat { get; set; }

//        public DoctorRepository(IDataSerializerService doctorSerializer, string dataFormat)
//            : base(doctorSerializer)
//        {
//            DataFormat = dataFormat;  // Сохраняем переданный параметр в поле
//            var config = ReadFromAppSettings();
//            //Path = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(DataFormat));
//            Path = PathHelper.GetDatabaseFilePath(config.Database.Doctors.Path);
//            LastId = config.Database.Doctors.LastId;
//        }

//        public override void ShowInfo(Doctor doctor)
//        {
//            Console.WriteLine($"Doctor: {doctor.Name} {doctor.Surname}, Type: {doctor.DoctorType}, Experience: {doctor.Experience} years");
//        }

//        protected override void SaveLastId()
//        {
//            dynamic result = ReadFromAppSettings();
//            result.Database.Doctors.LastId = LastId;

//            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(DataFormat));  // Используем сохраненное поле
//            File.WriteAllText(appSettingsPath, result.ToString());
//        }
//    }
//}



//using DoctorAppointmentDemo.Data.Interfaces;
//using MyDoctorAppointment.Data.Configuration;
//using MyDoctorAppointment.Data.Interfaces;
//using MyDoctorAppointment.Domain.Entities;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
//    {
//        public override string Path { get; set; }
//        public override int LastId { get; set; }
//        public override string DataFormat { get; set; }

//        public DoctorRepository(IDataSerializerService doctorSerializer, string dataFormat)
//            : base(doctorSerializer)
//        {
//            DataFormat = dataFormat;  // Сохраняем переданный параметр в поле
//            var config = ReadFromAppSettings();
//            Path = PathHelper.GetDatabaseFilePath(config.Database.Doctors.Path);
//            LastId = config.Database.Doctors.LastId;
//        }

//        public override void ShowInfo(Doctor doctor)
//        {
//            Console.WriteLine($"Doctor: {doctor.Name} {doctor.Surname}, Type: {doctor.DoctorType}, Experience: {doctor.Experience} years");
//        }

//        protected override void SaveLastId()
//        {
//            dynamic result = ReadFromAppSettings();
//            result.Database.Doctors.LastId = LastId;

//            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(DataFormat));
//            File.WriteAllText(appSettingsPath, result.ToString());
//        }

//        public override IEnumerable<Doctor> GetAll()
//        {
//            // Десериализация докторов из файла
//            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
//            {
//                // Используем _dataSerializer для десериализации
//                var doctorsCollection = _dataSerializer.Deserialize<DoctorsCollection>(Path);
//                return doctorsCollection?.Doctors ?? new List<Doctor>();
//            }
//            else
//            {
//                return base.GetAll(); 
//            }
//        }

//        public override Doctor Create(Doctor doctor)
//        {
//            var createdDoctor = base.Create(doctor);
//            // Сохраните обновленный список докторов после добавления нового
//            SaveDoctors(GetAll(), Path);
//            return createdDoctor;
//        }

//        private void SaveDoctors(IEnumerable<Doctor> doctors, string filePath)
//        {
//            var doctorsCollection = new DoctorsCollection { Doctors = doctors.ToList() };
//            // Используем _dataSerializer для сериализации
//            _dataSerializer.Serialize(doctorsCollection, filePath);
//        }
//    }
//}



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
            DataFormat = dataFormat;  // Устанавливаем формат данных
            var config = ReadFromAppSettings();
            Path = PathHelper.GetDatabaseFilePath(config.Database.Doctors.Path);
            LastId = config.Database.Doctors.LastId;
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
                // Для JSON возвращаем стандартную десериализацию через базовый метод
                return base.GetAll();
            }
        }

        protected override object CreateCollection(IEnumerable<Doctor> data)
        {
            // Создаем коллекцию для XML сериализации
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
