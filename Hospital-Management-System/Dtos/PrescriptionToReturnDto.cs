using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Entity.PatientModule;

namespace Hospital_Management_System.Dtos
{
    public class PrescriptionToReturnDto
    {
        public string DoctorName { get; set; }
        public string DoctorSpecialization { get; set; }
        public string MedicationName { get; set; }
        public string MedicationDescription { get; set; }
    }
}
