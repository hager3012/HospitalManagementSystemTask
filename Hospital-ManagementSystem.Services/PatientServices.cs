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
<<<<<<< HEAD
=======
<<<<<<< HEAD

=======
>>>>>>> 6d8b2c61e22d9027be0c68d3f088689c50f0f4b6
        /// <summary>
        /// Get patient information for specific patient
        /// </summary>
        /// <param name="patientId">string patient id</param>
        /// <returns>patient information</returns>
<<<<<<< HEAD
=======
>>>>>>> feature/Authentication
>>>>>>> 6d8b2c61e22d9027be0c68d3f088689c50f0f4b6
        public async Task<Patient?> GetPatientInfoAsync(string patientId)
        {
            var patient = await _patientDbContext.Set<Patient>().Where(P => P.Id== patientId).FirstOrDefaultAsync();
            return patient;
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> 6d8b2c61e22d9027be0c68d3f088689c50f0f4b6
        /// <summary>
        /// update patient information for specific patient
        /// </summary>
        /// <param name="patientId">string patient id</param>
        /// <param name="PatientModel">object for patient</param>
        /// <returns>number of row affected</returns>
<<<<<<< HEAD
=======
>>>>>>> feature/Authentication
>>>>>>> 6d8b2c61e22d9027be0c68d3f088689c50f0f4b6
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
