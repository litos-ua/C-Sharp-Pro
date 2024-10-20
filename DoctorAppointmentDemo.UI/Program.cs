using System;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Data.Interfaces;




namespace MyDoctorAppointment
{
    public static class Program
    {
        private static IDoctorRepository doctorRepository;
        private static IPatientRepository patientRepository;
        private static IAppointmentRepository appointmentRepository;

        public static void Main()
        {
            //var doctorService = new DoctorService();
            //var patientService = new PatientService();
            //var appointmentService = new AppointmentService();
            //var appointmentManager = new AppointmentManager(appointmentService, patientService, doctorService);
            //var app = new DoctorAppointment(doctorService, patientService, appointmentService);
            //app.Run();

            var doctorService = new DoctorService(doctorRepository);
            var patientService = new PatientService(patientRepository);
            var appointmentService = new AppointmentService(appointmentRepository, patientRepository, doctorRepository);

            var app = new DoctorAppointment(doctorService, patientService, appointmentService);
            app.Run();
        }
    }
}

