using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities
{
    public class MedicalHistory : BaseEntity
    {
        public ICollection<SurgicalHistory> SurgicalHistories { get; set; } = new HashSet<SurgicalHistory>();
        public ICollection<Past_illnesses> Past_Illnesses { get; set; } = new HashSet<Past_illnesses>();
        public VitalSigns VitalSigns { get; set; }
        public int RecordId { get; set; }
        public Record Record { get; set; } 
    }
}
