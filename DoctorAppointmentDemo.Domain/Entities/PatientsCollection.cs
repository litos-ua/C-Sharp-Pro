using System.Xml.Serialization;

namespace MyDoctorAppointment.Domain.Entities
{
    [XmlRoot("ArrayOfPatient")]
    public class PatientsCollection
    {
        [XmlElement("Patient")]
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}


