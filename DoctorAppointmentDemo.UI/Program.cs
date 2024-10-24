

using DoctorAppointmentDemo.UI;

namespace MyDoctorAppointment
{
    public static class Program
    {
        public static void Main()
        {
            // Creation UI menu menagers.
            var menuManager = new MenuManager();
            var dataFormatManager = new DataFormatManager();

            var app = new DoctorAppointment(menuManager, dataFormatManager);
            app.Run();
        }
    }
}
