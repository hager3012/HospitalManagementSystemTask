using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Dtos
{
    public class past_IllnessesDto
    {
        public string IllnessName { get; set; }
        public DateOnly DateOfIllness { get; set; }
        public string DurationOfIllness { get; set; }
        public bool FamilyHistory { get; set; }
    }
}
