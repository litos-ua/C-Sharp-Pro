
namespace MyDoctorAppointment.Data.Configuration
{
    public static class Constants
    {
        public static string AppSettingsPath(string dataFormat)
        {
            if (dataFormat == "XML")
            {
                return PathHelper.GetDatabaseFilePath("DoctorAppointmentDemo.Data/Configuration/appsettings_xml.json");
            }
            else // as default JSON
            {
                return PathHelper.GetDatabaseFilePath("DoctorAppointmentDemo.Data/Configuration/appsettings_json.json");
            }
        }
    }
}

