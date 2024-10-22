using System.Xml.Serialization;
using System.Collections.Generic;

namespace MyDoctorAppointment.Domain.Entities
{
    [XmlRoot("ArrayOfPatient")]
    public class PatientsCollection
    {
        [XmlElement("Patient")]
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
