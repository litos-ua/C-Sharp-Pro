

using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public DoctorRepository(IDataSerializerService doctorSerializer)
            : base(doctorSerializer)
        {
            dynamic result = ReadFromAppSettings();

            // Get relative path and last ID from appsettings.json
            //string relativePath = result.Database.Doctors.Path;
            //Path = PathHelper.GetDatabaseFilePath(relativePath);
            //LastId = result.Database.Doctors.LastId;
            var config = ReadFromAppSettings();
            Path = PathHelper.GetDatabaseFilePath(config.Database.Doctors.Path);
            LastId = config.Database.Doctors.LastId;
        }

        public override void ShowInfo(Doctor doctor)
        {
            Console.WriteLine($"Doctor: {doctor.Name} {doctor.Surname}, Type: {doctor.DoctorType}, Experience: {doctor.Experience} years");
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath);
            File.WriteAllText(appSettingsPath, result.ToString());  // Save the updated last ID
        }
    }
}
