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
        /// <summary>
        /// Retrieves detailed information for a specific patient based on the provided patient ID.
        /// </summary>
        /// <param name="patientId">A string representing the unique identifier of the patient.</param>
        /// <returns>
        /// An object containing detailed information about the specific patient, including their
        /// medical records, personal details, and relevant health information.
        /// </returns>
        /// <remarks>
        /// This method provides a comprehensive view of the patient's information, including but
        /// not limited to medical history, contact details, and other relevant data.
        /// </remarks>
        public async Task<Record?> ViewRecord(string patientId)
        {
            var record =await  _patientDbContext.Records.Where(R => R.PatientId==patientId).Include(R => R.Patient)
                .Include(R => R.MedicalHistory).ThenInclude(M => M.SurgicalHistories)
                .Include(R => R.MedicalHistory).ThenInclude(M => M.Past_Illnesses)
                .Include(R => R.MedicalHistory).ThenInclude(M => M.VitalSigns)
                .FirstOrDefaultAsync();
                
            return record;
        }
    }
}
