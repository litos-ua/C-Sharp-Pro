
//using DoctorAppointmentDemo.Data.Configuration;
//using DoctorAppointmentDemo.Data.Interfaces;
//using MyDoctorAppointment.Data.Configuration;
//using MyDoctorAppointment.Data.Interfaces;
//using MyDoctorAppointment.Domain.Entities;
//using Newtonsoft.Json;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public abstract class GenericRepository<TSource>(IDataSerializerService dataSerializer) : IGenericRepository<TSource> where TSource : Auditable
//    {
//        private readonly IDataSerializerService _dataSerializer = dataSerializer;

//        public abstract string Path { get; set; }
//        public abstract int LastId { get; set; }

//        public abstract string DataFormat { get; set; }

//        public TSource Create(TSource source)
//        {
//            source.Id = ++LastId;
//            source.CreatedAt = DateTime.Now;

//            var data = GetAll().Append(source);
//            _dataSerializer.Serialize(data, Path);  // Use the serializer to save data
//            SaveLastId();  // Save the updated last ID to configuration

//            return source;
//        }

//        public bool Delete(int id)
//        {
//            if (GetById(id) is null)
//                return false;

//            var data = GetAll().Where(x => x.Id != id);
//            _dataSerializer.Serialize(data, Path);  

//            return true;
//        }

//        public IEnumerable<TSource> GetAll()
//        {
//            return _dataSerializer.Deserialize<IEnumerable<TSource>>(Path);  
//        }

//        public TSource? GetById(int id)
//        {
//            return GetAll().FirstOrDefault(x => x.Id == id);
//        }

//        public TSource Update(int id, TSource source)
//        {
//            source.UpdatedAt = DateTime.Now;
//            source.Id = id;

//            var data = GetAll().Select(x => x.Id == id ? source : x);
//            _dataSerializer.Serialize(data, Path);  

//            return source;
//        }

//        public abstract void ShowInfo(TSource source);

//        protected abstract void SaveLastId();

//        // Utility method to read from app settings (could be used for file paths, configurations, etc.)
//        //protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath))!;
//        protected AppSettings ReadFromAppSettings()
//        {
//            var configJson = File.ReadAllText(Constants.AppSettingsPath(this.DataFormat));
//             return JsonConvert.DeserializeObject<AppSettings>(configJson);
//        }

//    }
//}

using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource>(IDataSerializerService dataSerializer) : IGenericRepository<TSource> where TSource : Auditable
    {
        public readonly IDataSerializerService _dataSerializer = dataSerializer;

        public abstract string Path { get; set; }
        public abstract int LastId { get; set; }

        public abstract string DataFormat { get; set; }

        //public TSource Create(TSource source)
        public virtual TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            var data = GetAll().Append(source);
            _dataSerializer.Serialize(data, Path);  // Use the serializer to save data
            SaveLastId();  // Save the updated last ID to configuration

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;

            var data = GetAll().Where(x => x.Id != id);
            _dataSerializer.Serialize(data, Path);

            return true;
        }

        //public IEnumerable<TSource> GetAll()
        public virtual IEnumerable<TSource> GetAll()
        {
            return _dataSerializer.Deserialize<IEnumerable<TSource>>(Path);
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            var data = GetAll().Select(x => x.Id == id ? source : x);
            _dataSerializer.Serialize(data, Path);

            return source;
        }

        public abstract void ShowInfo(TSource source);

        protected abstract void SaveLastId();

        // Utility method to read from app settings (could be used for file paths, configurations, etc.)
        //protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath))!;
        protected AppSettings ReadFromAppSettings()
        {
            var configJson = File.ReadAllText(Constants.AppSettingsPath(this.DataFormat));
            return JsonConvert.DeserializeObject<AppSettings>(configJson);
        }

    }
}