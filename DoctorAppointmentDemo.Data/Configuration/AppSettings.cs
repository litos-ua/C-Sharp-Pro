using System;

namespace DoctorAppointmentDemo.Data.Configuration
{
    public class AppSettings
    {
        //public string? DoctorFilePath { get; set; }
        //public string? PatientFilePath { get; set; }
        //public string? AppointmentFilePath { get; set; }
        public DatabaseSettings? Database { get; set; }
        public class DatabaseSettings
        {
            public DoctorSettings? Doctors { get; set; }
            public PatientSettings? Patients { get; set; }
            public AppointmentSettings? Appointments { get; set; }

        }

        public class DoctorSettings
        {
            public string? Path { get; set; }
            public int LastId { get; set; }
        }

        public class PatientSettings
        {
            public string? Path { get; set; }
            public int LastId { get; set; }
        }

        public class AppointmentSettings
        {
            public string? Path { get; set; }
            public int LastId { get; set; }
        }
    }


}
