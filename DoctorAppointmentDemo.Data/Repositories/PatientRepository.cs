
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Data.Interfaces;
using DoctorAppointmentDemo.Data.Interfaces;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public PatientRepository(IDataSerializerService patientSerializer)
            : base(patientSerializer)
        {
            //dynamic result = ReadFromAppSettings();

            //// Get relative path and last ID from appsettings.json
            //string relativePath = result.Database.Patients.Path;
            //Path = PathHelper.GetDatabaseFilePath(relativePath);
            //LastId = result.Database.Patients.LastId;
            var config = ReadFromAppSettings();
            Path = PathHelper.GetDatabaseFilePath(config.Database.Patients.Path);
            LastId = config.Database.Patients.LastId;

        }

        public override void ShowInfo(Patient patient)
        {
            Console.WriteLine($"{patient.Name} {patient.Surname} - {patient.IllnessType}");
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath);
            File.WriteAllText(appSettingsPath, result.ToString());  // Save the updated last ID
        }
    }
}
