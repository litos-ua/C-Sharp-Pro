//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using MyDoctorAppointment.Data.Interfaces;
//using MyDoctorAppointment.Domain.Entities;
//using MyDoctorAppointment.Data.Configuration;


//namespace MyDoctorAppointment.Data.Repositories
//{
//    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
//    {
//        public override string Path { get; set; }
//        public override int LastId { get; set; }

//        public AppointmentRepository()
//        {
//            dynamic result = ReadFromAppSettings();
//            Path = result.Database.Appointments.Path;
//            LastId = result.Database.Appointments.LastId;
//        }

//        public override void ShowInfo(Appointment appointment)
//        {
//            // Реализуйте вывод информации о записи на прием
//            Console.WriteLine($"Appointment from {appointment.DateTimeFrom} to {appointment.DateTimeTo} for patient {appointment.Patient?.Name} and doctor {appointment.Doctor?.Name}");
//        }

//        protected override void SaveLastId()
//        {
//            dynamic result = ReadFromAppSettings();
//            result.Database.Appointments.LastId = LastId;

//            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Data.Configuration;

//using MyDoctorAppointment.Data.Helpers; // Ensure you have the correct namespace for PathHelper

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public AppointmentRepository()
        {
            dynamic result = ReadFromAppSettings();
            string relativePath = result.Database.Appointments.Path;
            Path = PathHelper.GetDatabaseFilePath(relativePath);
            LastId = result.Database.Appointments.LastId;
        }

        public override void ShowInfo(Appointment appointment)
        {
            Console.WriteLine($"Appointment from {appointment.DateTimeFrom} to {appointment.DateTimeTo} for patient {appointment.Patient?.Name} and doctor {appointment.Doctor?.Name}");
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Appointments.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}

