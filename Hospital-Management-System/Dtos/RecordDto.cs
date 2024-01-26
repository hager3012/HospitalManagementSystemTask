using Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities;

namespace Hospital_Management_System.Dtos
{
    public class RecordDto
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Height { get; set; }
        public decimal Weigth { get; set; }
        public ICollection<surgicalHistoriesDto> SurgicalHistories { get; set; } = new HashSet<surgicalHistoriesDto>();
        public ICollection<past_IllnessesDto> Past_Illnesses { get; set; } = new HashSet<past_IllnessesDto>();
        public vitalSignsDto VitalSigns { get; set; }
    }
}
