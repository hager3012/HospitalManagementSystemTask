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
        public async Task<List<Doctor>?> GetDoctorsAsync()
        {
            var doctors =await _patientDbContext.Doctors.ToListAsync();
            return doctors;
        }
    }
}
