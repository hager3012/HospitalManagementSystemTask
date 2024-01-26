using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities
{
    public class VitalSigns : BaseEntity
    {
        public string BloodPressure { get; set; }
        public decimal HeartRate { get; set; }
        public decimal RespiratoryRate { get; set; }
        public decimal Temperature { get; set; }
    }
}
