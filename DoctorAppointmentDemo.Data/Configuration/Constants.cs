namespace MyDoctorAppointment.Data.Configuration
{

    public static class Constants
    {
        public static string AppSettingsPath
        {
            get
            {
                return PathHelper.GetDatabaseFilePath("DoctorAppointmentDemo.Data/Configuration/appsettings.json");
            }
        }
    }
}

