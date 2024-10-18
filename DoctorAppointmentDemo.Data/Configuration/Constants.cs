﻿namespace MyDoctorAppointment.Data.Configuration
{
    //public static class Constants
    //{
    //    // заменить на путь валидный для вашей директории на пк (в будущем будем использовать относительный путь)
    //    public const string AppSettingsPath = "C:\\Training\\Home work\\C#\\DoctorAppointmentDemo\\DoctorAppointmentDemo.Data\\Configuration\\appsettings.json";
    //}

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

