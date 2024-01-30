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
<<<<<<< HEAD
=======
<<<<<<< HEAD

=======
>>>>>>> 6d8b2c61e22d9027be0c68d3f088689c50f0f4b6
        /// <summary>
        /// Get record for specific patient
        /// </summary>
        /// <param name="patientId">string patient id</param>
        /// <returns> for specific patient</returns>
<<<<<<< HEAD
=======
>>>>>>> feature/Authentication
>>>>>>> 6d8b2c61e22d9027be0c68d3f088689c50f0f4b6
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
