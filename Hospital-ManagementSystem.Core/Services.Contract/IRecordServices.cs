using Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Services.Contract
{
    public interface IRecordServices
    {
        Task<Record?> ViewRecord(string IdPatient);
    }
}
