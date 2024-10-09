//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using MyDoctorAppointment.Data.Configuration;
//using MyDoctorAppointment.Domain.Entities;
//using MyDoctorAppointment.Data.Interfaces;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
//    {
//        public override string Path { get; set; }

//        public override int LastId { get; set; }

//        public PatientRepository()
//        {
//            dynamic result = ReadFromAppSettings();
//            Path = result.Database.Patients.Path;
//            LastId = result.Database.Patients.LastId;
//        }

//        public override void ShowInfo(Patient patient)
//        {
//            Console.WriteLine($"{patient.Name} {patient.Surname} - {patient.IllnessType}");
//        }

//        protected override void SaveLastId()
//        {
//            dynamic result = ReadFromAppSettings();
//            result.Database.Patients.LastId = LastId;
//            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
//        }
//    }
//}


using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Data.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public PatientRepository()
        {
            dynamic result = ReadFromAppSettings();

            // Resolve the relative path to the solution directory
            string relativePath = result.Database.Patients.Path;
            Path = PathHelper.GetDatabaseFilePath(relativePath);
            LastId = result.Database.Patients.LastId;
        }

        public override void ShowInfo(Patient patient)
        {
            Console.WriteLine($"{patient.Name} {patient.Surname} - {patient.IllnessType}");
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            // Resolve the path to app settings file relative to solution directory
            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath);
            File.WriteAllText(appSettingsPath, result.ToString());
        }
    }
}


