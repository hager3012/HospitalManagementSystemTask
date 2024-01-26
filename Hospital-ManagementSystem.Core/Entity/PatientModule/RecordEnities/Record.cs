using Hospital_ManagementSystem.Core.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities
{
    public class Record : BaseEntity
    {
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Height { get; set; }
        public decimal Weigth { get; set; }
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
    }
}
