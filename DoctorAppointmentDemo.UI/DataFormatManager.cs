using DoctorAppointmentDemo.Service.Services.Data;
using DoctorAppointmentDemo.UI.Enums;
using DoctorAppointmentDemo.Data.Interfaces;

namespace DoctorAppointmentDemo.UI
{
    public class DataFormatManager
    {
        public (IDataSerializerService doctorSerializer, IDataSerializerService patientSerializer, IDataSerializerService appointmentSerializer, string dataFormat) SetupDataFormat()
        {
            Console.WriteLine("Select data storage type: 1 - JSON, 2 - XML");
            string dataChoice = Console.ReadLine();

            IDataSerializerService doctorSerializer;
            IDataSerializerService patientSerializer;
            IDataSerializerService appointmentSerializer;
            string dataFormat;

            if (Enum.TryParse(dataChoice, out DataFormatEnum chosenFormat) && Enum.IsDefined(typeof(DataFormatEnum), chosenFormat))
            {
                switch (chosenFormat)
                {
                    case DataFormatEnum.JSON:
                        doctorSerializer = new JsonDataSerializerService();
                        patientSerializer = new JsonDataSerializerService();
                        appointmentSerializer = new JsonDataSerializerService();
                        dataFormat = "JSON";
                        break;
                    case DataFormatEnum.XML:
                        doctorSerializer = new XmlDataSerializerService();
                        patientSerializer = new XmlDataSerializerService();
                        appointmentSerializer = new XmlDataSerializerService();
                        dataFormat = "XML";
                        break;
                    default:
                        throw new InvalidOperationException("Unsupported data format.");
                }
            }
            else
            {
                doctorSerializer = new JsonDataSerializerService();
                patientSerializer = new JsonDataSerializerService();
                appointmentSerializer = new JsonDataSerializerService();
                dataFormat = "JSON";
                Console.WriteLine("Invalid option. Defaulting to JSON format.");
            }

            return (doctorSerializer, patientSerializer, appointmentSerializer, dataFormat);
        }
    }
}
