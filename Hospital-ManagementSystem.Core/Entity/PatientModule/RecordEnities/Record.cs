using Hospital_ManagementSystem.Core.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities
{
    public class Record : BaseEntity
    {
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int height { get; set; }
        public decimal width { get; set; }
        public Patient Patient { get; set; }
        public MedicalHistory? MedicalHistory { get; set; }
    }
}
