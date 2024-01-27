using Hospital_ManagementSystem.Core.Entity.PatientModule;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Dtos
{
    public class DoctorScheduleDto
    {
        [Required]
        public string Day { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string DoctorSpecialization { get; set; }
        [Required]
        public int DoctorId { get; set; }

    }
}
