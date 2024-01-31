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

        /// <summary>
        /// Asynchronously retrieves a list of all doctors from the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is a list of Doctor objects.
        /// </returns>
        public async Task<List<Doctor>?> GetDoctorsAsync()
        {
            var doctors = await _dbContext.Doctors.ToListAsync();
            return doctors;
        }

        /// <summary>
        /// Asynchronously retrieves all schedules for a specific doctor.
        /// </summary>
        /// <param name="doctorId">The unique identifier of the doctor.</param>
        /// <returns>
        /// A list of <see cref="DoctorSchedule"/> objects representing the schedules associated with the specified doctor.
        /// </returns>
        /// <remarks>
        /// This method retrieves the schedules for a specific doctor based on the provided <paramref name="doctorId"/>.
        /// </remarks>
        public async Task<List<DoctorSchedule>?> GetDoctorSchedulesAsync(int doctorId)
        {
            var doctorSchedules = await _dbContext.DoctorSchedules.Where(d => d.DoctorId == doctorId).Include(d => d.Doctor).ToListAsync();
            if (doctorSchedules.Count==0)
                return null;
            return doctorSchedules;
        }
    }
}
