using Hospital_ManagementSystem.Core.Entity.PatientModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Services.Contract
{
    public interface IAppointmentServices
    {
        Task<int> BookAppointment(string pateintId, Appointment appointment);
        Task<int> CancelAppointment(int appointmentId);
        Task<List<Appointment>> GetAppointments(string pateintId);
    }
}
