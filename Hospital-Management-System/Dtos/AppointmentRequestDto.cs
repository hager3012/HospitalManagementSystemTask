using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Entity.PatientModule;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Dtos
{
    public class AppointmentRequestDto
    {
        [Required]
        public string Day { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public DateOnly? Date { get; set; } = null;
        [Required]
        public TimeSpan? Time { get; set; } = null;
        public string? PatientId { get; set; }
    }
}
