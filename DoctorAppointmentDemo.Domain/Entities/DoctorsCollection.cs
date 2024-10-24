using System.Xml.Serialization;
using System.Collections.Generic;

namespace MyDoctorAppointment.Domain.Entities
{
    [XmlRoot("ArrayOfDoctor")]
    public class DoctorsCollection
    {
        [XmlElement("Doctor")]
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
