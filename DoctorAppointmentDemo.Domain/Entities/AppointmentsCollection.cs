using System.Xml.Serialization;
using System.Collections.Generic;

namespace MyDoctorAppointment.Domain.Entities
{
    [XmlRoot("ArrayOfAppointment")]
    public class AppointmentsCollection
    {
        [XmlElement("Appointment")]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}