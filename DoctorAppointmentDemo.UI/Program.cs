using System;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;




namespace MyDoctorAppointment
{
    public static class Program
    {
        public static void Main()
        {
            var doctorService = new DoctorService();
            var patientService = new PatientService();
            var appointmentService = new AppointmentService();
            var appointmentManager = new AppointmentManager(appointmentService, patientService, doctorService);
            var app = new DoctorAppointment(doctorService, patientService, appointmentService);
            app.Run();
        }
    }
}

