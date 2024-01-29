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
    public class AppointmentServices : IAppointmentServices
    {
        private readonly PatientDbContext _dbContext;

        public AppointmentServices(PatientDbContext dbContext)
        {
            _dbContext = dbContext;
        }
<<<<<<< HEAD
=======
        /// <summary>
        /// Book Appointment for patient 
        /// </summary>
        /// <param name="pateintId">string patient Id</param>
        /// <param name="appointment">object from Appointment To Book Appointment </param>
        /// <returns>0 if faild Booking
        /// 1 if Success
        /// -1 if theis patient have appointment in this time </returns>
>>>>>>> feature/Authentication
        public async Task<int> BookAppointment(string pateintId, Appointment appointment)
        {
            var checkBookAvilable =await _dbContext.Appointments.Where(A => A.Patient.Id == pateintId && 
            A.Date== appointment.Date && A.Time == appointment.Time).FirstOrDefaultAsync();
            if (checkBookAvilable is not null)
                return -1;
            _dbContext.Appointments.Add(appointment);
            return _dbContext.SaveChanges();

        }
<<<<<<< HEAD

=======
        /// <summary>
        /// Cancel Appointment for patient 
        /// </summary>
        /// <param name="appointmentId">int Appointment Id</param>
        /// <returns>0 if faild Cancel 
        /// 1 if Success </returns>
>>>>>>> feature/Authentication
        public async Task<int> CancelAppointment(int appointmentId)
        {
            var appointmentCancel = await _dbContext.Appointments.FirstOrDefaultAsync(A => A.Id == appointmentId);
            _dbContext.Appointments.Remove(appointmentCancel);
            return _dbContext.SaveChanges();
        }
<<<<<<< HEAD

=======
        /// <summary>
        /// Get All Appointment for patient 
        /// </summary>
        /// <param name="pateintId">string patient Id</param>
        /// <returns>List of Appointment</returns>
>>>>>>> feature/Authentication
        public async Task<List<Appointment>> GetAppointments(string pateintId)
        {
            var appointments = await _dbContext.Appointments.Where(A => A.Patient.Id == pateintId).Include(A => A.Doctor).ToListAsync();
            return appointments;
        }
        
    }
}
