using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Entity.PatientModule;

namespace Hospital_Management_System.Dtos
{
    public class AppointmentReturnDto
    {
        public int AppointmentId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpecialization { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
