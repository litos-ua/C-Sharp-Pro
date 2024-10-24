


using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Service.Services;
using DoctorAppointmentDemo.UI;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly MenuManager _menuManager;
        private readonly DataFormatManager _dataFormatManager;

        private DoctorManager _doctorManager;
        private PatientManager _patientManager;
        private AppointmentManager _appointmentManager;

        public DoctorAppointment(MenuManager menuManager, DataFormatManager dataFormatManager)
        {
            _menuManager = menuManager;
            _dataFormatManager = dataFormatManager;
        }

        public void Run()
        {
            // data 
            var (doctorSerializer, patientSerializer, appointmentSerializer, dataFormat) = _dataFormatManager.SetupDataFormat();

            var doctorRepository = new DoctorRepository(doctorSerializer, dataFormat);
            var patientRepository = new PatientRepository(patientSerializer, dataFormat);
            var appointmentRepository = new AppointmentRepository(appointmentSerializer, dataFormat);

            _doctorManager = new DoctorManager(new DoctorService(doctorRepository));
            _patientManager = new PatientManager(new PatientService(patientRepository));
            _appointmentManager = new AppointmentManager(
                new AppointmentService(appointmentRepository, patientRepository, doctorRepository),
                new PatientService(patientRepository),
                new DoctorService(doctorRepository)
            );

            // Start main menu
            _menuManager.DisplayMenu(_doctorManager, _patientManager, _appointmentManager);
        }
    }
}
