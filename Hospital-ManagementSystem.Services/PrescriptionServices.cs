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
        public async Task<List<Prescription>> GetAllPrescriptionsForPatient(string patientId)
        {
            var prescriptions = await _dbContext.Prescriptions.Where(P => P.PatientId == patientId).Include(P => P.Doctor).ToListAsync();
            return prescriptions;
        }

        public async Task<Prescription?> GetPrescription(string patientId, int doctorId)
        {
            var prescription = await _dbContext.Prescriptions.Where(P => P.PatientId == patientId && P.DoctorId == doctorId).Include(P => P.Doctor).FirstOrDefaultAsync();
            return prescription;
        }
    }
}
