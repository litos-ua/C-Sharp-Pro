using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        // patient's methods
    }
}

