
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
//        public readonly IDataSerializerService _dataSerializer = dataSerializer;

//        public abstract string Path { get; set; }
//        public abstract int LastId { get; set; }

//        public abstract string DataFormat { get; set; }

//        //public TSource Create(TSource source)
//        public virtual TSource Create(TSource source)
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

//        //public IEnumerable<TSource> GetAll()
//        public virtual IEnumerable<TSource> GetAll()
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
//            return JsonConvert.DeserializeObject<AppSettings>(configJson);
//        }

//    }
//}


///* Работает с json и как-то с xml (читает нормально, пишет с ошибкой)*/

//using DoctorAppointmentDemo.Data.Configuration;
//using DoctorAppointmentDemo.Data.Interfaces;
//using MyDoctorAppointment.Data.Configuration;
//using MyDoctorAppointment.Data.Interfaces;
//using MyDoctorAppointment.Domain.Entities;
//using Newtonsoft.Json;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
//    {
//        protected readonly IDataSerializerService _dataSerializer;

//        public abstract string Path { get; set; }
//        public abstract int LastId { get; set; }
//        public abstract string DataFormat { get; set; }

//        protected GenericRepository(IDataSerializerService dataSerializer)
//        {
//            _dataSerializer = dataSerializer;
//        }

//        public virtual TSource Create(TSource source)
//        {
//            source.Id = ++LastId;  // Увеличиваем LastId
//            source.CreatedAt = DateTime.Now;

//            // Получаем все данные и добавляем новый элемент
//            var data = GetAll().Append(source);

//            // Проверяем формат данных
//            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
//            {
//                // Для XML используем коллекцию
//                var collection = CreateCollection(data);
//                _dataSerializer.Serialize(collection, Path);  // Сериализуем коллекцию в XML
//            }
//            else
//            {
//                // Для JSON сохраняем список
//                _dataSerializer.Serialize(data, Path);  // Сериализуем список в JSON
//            }

//            SaveLastId();  // Сохраняем обновленный LastId

//            return source;
//        }

//        public virtual TSource? GetById(int id)
//        {
//            // Поиск элемента по Id
//            return GetAll().FirstOrDefault(x => x.Id == id);
//        }

//        public virtual TSource Update(int id, TSource source)
//        {
//            source.Id = id;
//            source.UpdatedAt = DateTime.Now;

//            // Обновляем данные
//            var data = GetAll().Select(x => x.Id == id ? source : x);

//            // Проверяем формат данных
//            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
//            {
//                // Для XML обновляем коллекцию
//                var collection = CreateCollection(data);
//                _dataSerializer.Serialize(collection, Path);  // Сериализуем коллекцию в XML
//            }
//            else
//            {
//                // Для JSON обновляем список
//                _dataSerializer.Serialize(data, Path);  // Сериализуем список в JSON
//            }

//            return source;
//        }

//        public virtual IEnumerable<TSource> GetAll()
//        {
//            // Десериализация данных в зависимости от формата
//            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
//            {
//                var collection = _dataSerializer.Deserialize<IEnumerable<TSource>>(Path);
//                return collection ?? new List<TSource>();
//            }
//            else
//            {
//                return _dataSerializer.Deserialize<IEnumerable<TSource>>(Path) ?? new List<TSource>();
//            }
//        }

//        public virtual bool Delete(int id)
//        {
//            var source = GetById(id);
//            if (source == null)
//                return false;

//            // Удаление элемента
//            var data = GetAll().Where(x => x.Id != id);

//            // Проверяем формат данных
//            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
//            {
//                // Для XML сериализуем коллекцию
//                var collection = CreateCollection(data);
//                _dataSerializer.Serialize(collection, Path);
//            }
//            else
//            {
//                // Для JSON сохраняем обновленный список
//                _dataSerializer.Serialize(data, Path);
//            }

//            return true;
//        }

//        // Абстрактные методы для создания коллекции и сохранения LastId
//        protected abstract object CreateCollection(IEnumerable<TSource> data);
//        protected abstract void SaveLastId();

//        protected AppSettings ReadFromAppSettings()
//        {
//            var configJson = File.ReadAllText(Constants.AppSettingsPath(this.DataFormat));
//            return JsonConvert.DeserializeObject<AppSettings>(configJson);
//        }
//    }
//}
///*--------------------------------------------------------------------------------------------------------*/

using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        protected readonly IDataSerializerService _dataSerializer;

        public abstract string Path { get; set; } 
        public abstract int LastId { get; set; }  
        public abstract string DataFormat { get; set; } 

        protected GenericRepository(IDataSerializerService dataSerializer)
        {
            _dataSerializer = dataSerializer;
        }

        public virtual TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            if (!File.Exists(Path))
            {
                if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
                {
                    var emptyCollection = CreateCollection(new List<TSource>());
                    _dataSerializer.Serialize(emptyCollection, Path);  
                }
                else
                {
                    // For JSON, start with an empty list
                    _dataSerializer.Serialize(new List<TSource>(), Path);  
                }
            }

            // Get the current data and append the new source
            var data = GetAll().Append(source);

            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {

                try
                {
                    // Явное приведение к PatientsCollection
                    var collection = CreateCollection(data) as PatientsCollection;

                    // Проверка, что приведение успешно
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

            SaveLastId();  // Save the updated LastId

            return source;
        }


        public virtual TSource? GetById(int id)
        {
            // Поиск элемента по Id
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public virtual TSource Update(int id, TSource source)
        {
            source.Id = id;
            source.UpdatedAt = DateTime.Now;

            // Обновляем данные
            var data = GetAll().Select(x => x.Id == id ? source : x);

            // Проверяем формат данных
            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {
                // Для XML обновляем коллекцию
                var collection = CreateCollection(data);
                _dataSerializer.Serialize(collection, Path);  // Сериализуем коллекцию в XML
            }
            else
            {
                // Для JSON обновляем список
                _dataSerializer.Serialize(data, Path);  // Сериализуем список в JSON
            }

            return source;
        }

        public virtual IEnumerable<TSource> GetAll()
        {
            // Если файл не существует, возвращаем пустую коллекцию
            if (!File.Exists(Path))
            {
                return new List<TSource>();
            }

            // Десериализация данных в зависимости от формата
            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {
                var collection = _dataSerializer.Deserialize<IEnumerable<TSource>>(Path);
                return collection ?? new List<TSource>();
            }
            else
            {
                return _dataSerializer.Deserialize<IEnumerable<TSource>>(Path) ?? new List<TSource>();
            }
        }

        public virtual bool Delete(int id)
        {
            var source = GetById(id);
            if (source == null)
                return false;

            // Удаление элемента
            var data = GetAll().Where(x => x.Id != id);

            // Проверяем формат данных
            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {
                // Для XML сериализуем коллекцию
                var collection = CreateCollection(data);
                _dataSerializer.Serialize(collection, Path);
            }
            else
            {
                // Для JSON сохраняем обновленный список
                _dataSerializer.Serialize(data, Path);
            }

            return true;
        }


        // Абстрактные методы для создания коллекции и сохранения LastId
        protected abstract object CreateCollection(IEnumerable<TSource> data);
        protected abstract void SaveLastId();

        protected AppSettings ReadFromAppSettings()
        {
            var configJson = File.ReadAllText(Constants.AppSettingsPath(this.DataFormat));
            return JsonConvert.DeserializeObject<AppSettings>(configJson);
        }
    }

}