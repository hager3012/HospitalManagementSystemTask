using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Entity.PatientModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Services.Contract
{
    public interface IPatientServices
    {
        Task<Patient?> GetPatientInfoAsync(string patientId);
        Task<int> UpdatePatientInfoAsync(string patientId, Patient patient);
    }
}
