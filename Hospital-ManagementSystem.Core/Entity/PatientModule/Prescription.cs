using Hospital_ManagementSystem.Core.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.PatientModule
{
    public class Prescription:BaseEntity
    {
        public string MedicationName { get; set; }
        public string MedicationDescription { get; set;}
        public int PatientId { get; set; }
        public Patient  Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
