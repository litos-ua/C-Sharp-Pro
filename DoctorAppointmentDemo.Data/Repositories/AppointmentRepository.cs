
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public AppointmentRepository(IDataSerializerService appointmentSerializer)
            : base(appointmentSerializer)
        {
            //dynamic result = ReadFromAppSettings();

            //// Resolve relative path and last ID from appsettings.json
            //string relativePath = result.Database.Appointments.Path;
            //Path = PathHelper.GetDatabaseFilePath(relativePath);
            //LastId = result.Database.Appointments.LastId;

            var config = ReadFromAppSettings();
            Path = PathHelper.GetDatabaseFilePath(config.Database.Appointments.Path);
            LastId = config.Database.Appointments.LastId;
        }

        public override void ShowInfo(Appointment appointment)
        {
            Console.WriteLine($"Appointment from {appointment.DateTimeFrom} to {appointment.DateTimeTo} for patient {appointment.Patient?.Name} and doctor {appointment.Doctor?.Name}");
        }

        // Save the last used appointment ID to the appsettings.json file
        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Appointments.LastId = LastId;

            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath);
            File.WriteAllText(appSettingsPath, result.ToString());  // Save the updated last ID
        }
    }
}
