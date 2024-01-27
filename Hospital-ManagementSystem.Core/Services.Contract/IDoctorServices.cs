using Hospital_ManagementSystem.Core.Entity.PatientModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Services.Contract
{
    public interface IDoctorServices
    {
        Task<List<Doctor>?> GetDoctorsAsync();
        Task<List<DoctorSchedule>?> GetDoctorSchedulesAsync(int doctorId);
    }
}
