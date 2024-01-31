using Hospital_ManagementSystem.Core.Entity.PatientModule;
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
    public class PrescriptionServices : IPrescriptionServices
    {
        private readonly PatientDbContext _dbContext;

        public PrescriptionServices(PatientDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves a list of all prescriptions associated with a specific patient.
        /// </summary>
        /// <param name="patientId">The unique identifier of the patient.</param>
        /// <returns>A list of prescriptions for the specified patient.</returns>
        /// <remarks>
        /// This method fetches all prescriptions linked to the provided patient identifier.
        /// </remarks>
        /// /// <remarks>
        /// The returned list may be empty if the patient has no prescriptions.
        /// </remarks>
        public async Task<List<Prescription>> GetAllPrescriptionsForPatient(string patientId)
        {
            var prescriptions = await _dbContext.Prescriptions.Where(P => P.PatientId == patientId).Include(P => P.Doctor).ToListAsync();
            return prescriptions;
        }
        /// <summary>
        /// Retrieves the prescriptions for a specific patient based on the patient's ID and the doctor's ID.
        /// </summary>
        /// <param name="patientId">The unique identifier of the patient (string).</param>
        /// <param name="doctorId">The unique identifier of the doctor (int).</param>
        /// <returns>
        /// A collection of prescriptions associated with the specified patient.
        /// Each prescription object contains details such as medication, dosage, and instructions.
        /// If no prescriptions are found, an empty collection is returned.
        /// </returns>
        /// <remarks>
        /// This method fetches the prescriptions for a specific patient as recorded by the doctor.
        /// The patient's ID is used to identify the patient, and the doctor's ID is used to ensure
        /// that only prescriptions from the authorized doctor are retrieved.
        /// </remarks>
        public async Task<Prescription?> GetPrescription(string patientId, int doctorId)
        {
            var prescription = await _dbContext.Prescriptions.Where(P => P.PatientId == patientId && P.DoctorId == doctorId).Include(P => P.Doctor).FirstOrDefaultAsync();
            return prescription;
        }
    }
}
