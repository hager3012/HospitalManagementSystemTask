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
    public class DoctorServices:IDoctorServices
    {
        private readonly PatientDbContext _dbContext;

        public DoctorServices(PatientDbContext dbContext)
        {
            _dbContext = dbContext;
        }
<<<<<<< HEAD
=======
        /// <summary>
        /// Get All Doctors Async
        /// </summary>
        /// <returns>List of Doctor</returns>
>>>>>>> feature/Authentication
        public async Task<List<Doctor>?> GetDoctorsAsync()
        {
            var doctors = await _dbContext.Doctors.ToListAsync();
            return doctors;
        }
<<<<<<< HEAD

=======
        /// <summary>
        /// Get All schedules Async for specific doctor
        /// </summary>
        /// <param name="doctorId">int doctor Id</param>
        /// <returns>List of Doctor Schedule </returns>
>>>>>>> feature/Authentication
        public async Task<List<DoctorSchedule>?> GetDoctorSchedulesAsync(int doctorId)
        {
            var doctorSchedules = await _dbContext.DoctorSchedules.Where(d => d.DoctorId == doctorId).Include(d => d.Doctor).ToListAsync();
            if (doctorSchedules.Count==0)
                return null;
            return doctorSchedules;
        }
    }
}
