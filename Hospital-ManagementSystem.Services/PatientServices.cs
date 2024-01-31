using Hospital_ManagementSystem.Core.Entity.Identity;
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
    public class PatientServices : IPatientServices
    {
        private readonly PatientDbContext _patientDbContext;

        public PatientServices(PatientDbContext patientDbContext)
        {
            _patientDbContext = patientDbContext;
        }
        /// <summary>
        /// Retrieves detailed information about a specific patient based on their unique identifier.
        /// </summary>
        /// <param name="patientId">A string representing the unique identifier of the patient.</param>
        /// <returns>
        /// Returns an object containing comprehensive information about the patient,
        /// including their personal details, medical history, and contact information.
        /// </returns>
        /// <remarks>
        /// This method provides a detailed snapshot of the patient's information.
        /// </remarks>
        public async Task<Patient?> GetPatientInfoAsync(string patientId)
        {
            var patient = await _patientDbContext.Set<Patient>().Where(P => P.Id== patientId).FirstOrDefaultAsync();
            return patient;
        }
        /// <summary>
        /// Updates patient information for a specific patient identified by the provided patient ID.
        /// </summary>
        /// <param name="PatientId">A unique string identifier for the patient.</param>
        /// <param name="PatientModel">An object containing updated patient information.</param>
        /// <returns>The number of rows affected in the database after the update operation.</returns>
        /// <remarks>
        /// This method allows you to modify the information of a patient in the system.
        /// </remarks>
        public async Task<int> UpdatePatientInfoAsync(string  PatientId, Patient PatientModel)
        {
            var patient = await _patientDbContext.Set<Patient>().FirstOrDefaultAsync(P => P.Id == PatientId);
            if (patient is null)
                return 0;
            patient.FristName = PatientModel.FristName;
            patient.LastName = PatientModel.LastName;
            patient.Email = PatientModel.Email;
            patient.UserName = PatientModel.UserName;

            var patientUpdated = _patientDbContext.SaveChanges();
            return patientUpdated;
        }
    }
}
