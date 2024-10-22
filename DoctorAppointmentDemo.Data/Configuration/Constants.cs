//namespace MyDoctorAppointment.Data.Configuration
//{

//    public static class Constants
//    {
//        public static string AppSettingsPath
//        {
//            get
//            {
//                return PathHelper.GetDatabaseFilePath("DoctorAppointmentDemo.Data/Configuration/appsettings.json");
//            }
//        }
//    }
//}

namespace MyDoctorAppointment.Data.Configuration
{
    public static class Constants
    {
        // Метод, который принимает dataFormat и возвращает нужный путь
        public static string AppSettingsPath(string dataFormat)
        {
            if (dataFormat == "XML")
            {
                return PathHelper.GetDatabaseFilePath("DoctorAppointmentDemo.Data/Configuration/appsettings_xml.json");
            }
            else // По умолчанию JSON
            {
                return PathHelper.GetDatabaseFilePath("DoctorAppointmentDemo.Data/Configuration/appsettings_json.json");
            }
        }
    }
}

