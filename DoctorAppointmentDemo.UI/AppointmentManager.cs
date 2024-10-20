
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;


namespace MyDoctorAppointment

{
    public class AppointmentManager
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public AppointmentManager(IAppointmentService appointmentService, IPatientService patientService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }


        public void ViewAppointments()
        {
            var appointments = _appointmentService.GetAll();
            Console.WriteLine("Appointments List:");
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"{appointment.Id}. Doctor: {appointment.Doctor?.Name}, Patient: {appointment.Patient?.Name}, Date: {appointment.DateTimeFrom}");
            }
        }

        public void AddAppointment()
        {
            Console.WriteLine("Enter patient ID:");
            int patientId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter doctor ID:");
            int doctorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter start date and time (yyyy-MM-dd HH:mm):");
            DateTime startDateTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter end date and time (yyyy-MM-dd HH:mm):");
            DateTime endDateTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter appointment description:");
            string description = Console.ReadLine();

            var patient = _patientService.Get(patientId);
            var doctor = _doctorService.Get(doctorId);

            if (patient == null || doctor == null)
            {
                Console.WriteLine("Invalid patient or doctor ID.");
                return;
            }


            _appointmentService.Create(patient, doctor, startDateTime, endDateTime, description);
            Console.WriteLine("Appointment added successfully.");
        }

        public void EditAppointment()
        {

            Console.WriteLine("Enter appointment ID:");
            int appointmentId = int.Parse(Console.ReadLine());
            var appointment = _appointmentService.Get(appointmentId);

            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            } 

            _appointmentService.Update(appointmentId, appointment);
            Console.WriteLine("Appointment updated successfully.");
        }

        public void DeleteAppointment()
        {
            Console.WriteLine("Enter appointment ID to delete:");
            int appointmentId = int.Parse(Console.ReadLine());
            bool isDeleted = _appointmentService.Delete(appointmentId);

            if (isDeleted)
                Console.WriteLine("Appointment deleted successfully.");
            else
                Console.WriteLine("Appointment not found.");
        }




    }

}
