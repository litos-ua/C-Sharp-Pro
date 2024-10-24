
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
                    // JSON
                    _dataSerializer.Serialize(new List<TSource>(), Path);
                }
            }
            var data = GetAll().Append(source);

            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {

                //create in the children

            }
            else
            {
                // For JSON
                _dataSerializer.Serialize(data, Path);
            }

            SaveLastId();  

            return source;
        }


        public virtual TSource? GetById(int id)
        {
            // Search by Id
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public virtual TSource Update(int id, TSource source)
        {
            source.Id = id;
            source.UpdatedAt = DateTime.Now;

            // Refresh data
            var data = GetAll().Select(x => x.Id == id ? source : x);

            // Check data format
            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {
                // New collection (XML)
                var collection = CreateCollection(data);
                _dataSerializer.Serialize(collection, Path);  // to XML
            }
            else
            {
                // new list for JSON
                _dataSerializer.Serialize(data, Path);  // to JSON
            }

            return source;
        }

        public virtual IEnumerable<TSource> GetAll()
        {
            if (!File.Exists(Path))
            {
                return new List<TSource>();
            }

            // Deserialization of data depending on format
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

            // Delete the element by Id
            var data = GetAll().Where(x => x.Id != id);

            if (DataFormat.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {
                var collection = CreateCollection(data);
                _dataSerializer.Serialize(collection, Path);
            }
            else
            {
                // For JSON 
                _dataSerializer.Serialize(data, Path);
            }

            return true;
        }


        protected abstract object CreateCollection(IEnumerable<TSource> data);
        protected abstract void SaveLastId();

        protected AppSettings ReadFromAppSettings()
        {
            var configJson = File.ReadAllText(Constants.AppSettingsPath(this.DataFormat));
            return JsonConvert.DeserializeObject<AppSettings>(configJson);
        }
    }

}



