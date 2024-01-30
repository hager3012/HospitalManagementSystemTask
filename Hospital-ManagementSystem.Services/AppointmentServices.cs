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

        /// <summary>
        /// Books an appointment for a patient.
        /// </summary>
        /// <param name="patientId">The unique identifier of the patient (string).</param>
        /// <param name="appointment">The appointment details to book (Appointment object).</param>
        /// <returns>
        ///  1: Successful booking.
        ///  0: Failed booking.
        /// -1: The patient already has an appointment at the specified time.
        /// </returns>
        /// <remarks>
        /// The method attempts to schedule an appointment for the specified patient at the given time.
        /// Returns 1 if the booking is successful, 0 if the booking fails, and -1 if the patient already
        /// has an appointment at the specified time.
        /// </remarks>
        public async Task<int> BookAppointment(string pateintId, Appointment appointment)
        {
            var checkBookAvilable =await _dbContext.Appointments.Where(A => A.Patient.Id == pateintId && 
            A.Date== appointment.Date && A.Time == appointment.Time).FirstOrDefaultAsync();
            if (checkBookAvilable is not null)
                return -1;
            _dbContext.Appointments.Add(appointment);
            return _dbContext.SaveChanges();

        }
/// <summary>
/// Cancels an appointment for a patient based on the provided appointment ID.
/// </summary>
/// <param name="appointmentId">The unique identifier of the appointment to be canceled.</param>
/// <returns>
/// 0 if the cancellation failed.
/// 1 if the cancellation was successful.
/// </returns>
        public async Task<int> CancelAppointment(int appointmentId)
        {
            var appointmentCancel = await _dbContext.Appointments.FirstOrDefaultAsync(A => A.Id == appointmentId);
            _dbContext.Appointments.Remove(appointmentCancel);
            return _dbContext.SaveChanges();
        }

/// <summary>
/// Retrieves a list of all appointments for a specific patient.
/// </summary>
/// <param name="patientId">The unique identifier for the patient (string).</param>
/// <returns>A list of Appointment objects representing the patient's appointments.</returns>
/// <remarks>
/// This method fetches all appointments associated with the specified patient ID.
/// </remarks>
        public async Task<List<Appointment>> GetAppointments(string pateintId)
        {
            var appointments = await _dbContext.Appointments.Where(A => A.Patient.Id == pateintId).Include(A => A.Doctor).ToListAsync();
            return appointments;
        }
        
    }
}
