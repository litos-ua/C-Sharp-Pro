
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public abstract string Path { get; set; }

        public abstract int LastId { get; set; }

        private string GetFullPath() => PathHelper.GetDatabaseFilePath(Path);

        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            var data = GetAll().Append(source);
            File.WriteAllText(GetFullPath(), JsonConvert.SerializeObject(data, Formatting.Indented));
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;

            var data = GetAll().Where(x => x.Id != id);
            File.WriteAllText(GetFullPath(), JsonConvert.SerializeObject(data, Formatting.Indented));

            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            string fullPath = GetFullPath();

            if (!File.Exists(fullPath))
            {
                 File.WriteAllText(fullPath, "[]");
            }

            var json = File.ReadAllText(fullPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(fullPath, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<List<TSource>>(json)!;
        }

        public TSource? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            var data = GetAll().Select(x => x.Id == id ? source : x);
            File.WriteAllText(GetFullPath(), JsonConvert.SerializeObject(data, Formatting.Indented));

            return source;
        }

        public abstract void ShowInfo(TSource source);

        protected abstract void SaveLastId();

        protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath))!;
    }
}

