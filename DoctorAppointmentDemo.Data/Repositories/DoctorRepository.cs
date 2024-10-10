
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public DoctorRepository()
        {
            dynamic result = ReadFromAppSettings();

            // Using PathHelper to resolve the full path relative to the solution directory
            string relativePath = result.Database.Doctors.Path;
            Path = PathHelper.GetDatabaseFilePath(relativePath);
            LastId = result.Database.Doctors.LastId;
        }

        public override void ShowInfo(Doctor doctor)
        {
            Console.WriteLine($"Doctor: {doctor.Name} {doctor.Surname}, Type: {doctor.DoctorType}, Experience: {doctor.Experience} years");
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            // Ensure the app settings path is correctly resolved using PathHelper
            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath);
            File.WriteAllText(appSettingsPath, result.ToString());
        }
    }
}

