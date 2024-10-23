
//using MyDoctorAppointment.Data.Interfaces;
//using MyDoctorAppointment.Domain.Entities;
//using MyDoctorAppointment.Data.Configuration;
//using DoctorAppointmentDemo.Data.Interfaces;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
//    {
//        public override string Path { get; set; }
//        public override int LastId { get; set; }
//        public override string DataFormat { get; set; }

//        public AppointmentRepository(IDataSerializerService appointmentSerializer, string dataFormat)
//            : base(appointmentSerializer)
//        {

//            var config = ReadFromAppSettings();
//            Path = PathHelper.GetDatabaseFilePath(config.Database.Appointments.Path);
//            LastId = config.Database.Appointments.LastId;
//        }

//        public override void ShowInfo(Appointment appointment)
//        {
//            Console.WriteLine($"Appointment from {appointment.DateTimeFrom} to {appointment.DateTimeTo} for patient {appointment.Patient?.Name} and doctor {appointment.Doctor?.Name}");
//        }

//        // Save the last used appointment ID to the appsettings.json file
//        protected override void SaveLastId()
//        {
//            dynamic result = ReadFromAppSettings();
//            result.Database.Appointments.LastId = LastId;

//            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(this.DataFormat));
//            File.WriteAllText(appSettingsPath, result.ToString());  // Save the updated last ID
//        }
//    }
//}


//using MyDoctorAppointment.Data.Interfaces;
//using MyDoctorAppointment.Domain.Entities;
//using MyDoctorAppointment.Data.Configuration;
//using DoctorAppointmentDemo.Data.Interfaces;

//namespace MyDoctorAppointment.Data.Repositories
//{
//    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
//    {
//        public override string Path { get; set; }
//        public override int LastId { get; set; }
//        public override string DataFormat { get; set; }

//        public AppointmentRepository(IDataSerializerService appointmentSerializer, string dataFormat)
//            : base(appointmentSerializer)
//        {
//            DataFormat = dataFormat;
//            var config = ReadFromAppSettings();
//            Path = PathHelper.GetDatabaseFilePath(config.Database.Appointments.Path);
//            LastId = config.Database.Appointments.LastId;
//        }

//        public override void ShowInfo(Appointment appointment)
//        {
//            Console.WriteLine($"Appointment from {appointment.DateTimeFrom} to {appointment.DateTimeTo} for patient {appointment.Patient?.Name} and doctor {appointment.Doctor?.Name}");
//        }

//        // Save the last used appointment ID to the appsettings.json file
//        protected override void SaveLastId()
//        {
//            dynamic result = ReadFromAppSettings();
//            result.Database.Appointments.LastId = LastId;

//            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(DataFormat));
//            File.WriteAllText(appSettingsPath, result.ToString());  // Save the updated last ID
//        }
//    }
//}

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
        public override string DataFormat { get; set; }

        public AppointmentRepository(IDataSerializerService appointmentSerializer, string dataFormat)
            : base(appointmentSerializer)
        {
            DataFormat = dataFormat;
            var config = ReadFromAppSettings();
            Path = PathHelper.GetDatabaseFilePath(config.Database.Appointments.Path);
            LastId = config.Database.Appointments.LastId;
        }

        protected override object CreateCollection(IEnumerable<Appointment> data)
        {
            // Создаем коллекцию для XML сериализации
            return new AppointmentsCollection { Patients = data.ToList() };
        }

        //public override void ShowInfo(Appointment appointment)
        //{
        //    Console.WriteLine($"Appointment from {appointment.DateTimeFrom} to {appointment.DateTimeTo} for patient {appointment.Patient?.Name} and doctor {appointment.Doctor?.Name}");
        //}

        // Save the last used appointment ID to the appsettings.json file
        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Appointments.LastId = LastId;

            string appSettingsPath = PathHelper.GetDatabaseFilePath(Constants.AppSettingsPath(DataFormat));
            File.WriteAllText(appSettingsPath, result.ToString());  // Save the updated last ID
        }
    }
}