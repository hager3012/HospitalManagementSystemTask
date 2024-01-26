using Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities;
using Hospital_ManagementSystem.Core.Services.Contract;
using Hospital_ManagementSystem.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Services
{
    public class RecordServices : IRecordServices
    {
        private readonly PatientDbContext _patientDbContext;

        public RecordServices(PatientDbContext patientDbContext)
        {
            _patientDbContext = patientDbContext;
        }

        public async Task<Record?> ViewRecord(string IdPatient)
        {
            var record =await  _patientDbContext.Records.Where(R => R.PatientId==IdPatient).Include(R => R.Patient)
                .Include(R => R.MedicalHistory).ThenInclude(M => M.SurgicalHistories)
                .Include(R => R.MedicalHistory).ThenInclude(M => M.Past_Illnesses)
                .Include(R => R.MedicalHistory).ThenInclude(M => M.VitalSigns)
                .FirstOrDefaultAsync();
                
            return record;
        }
    }
}
