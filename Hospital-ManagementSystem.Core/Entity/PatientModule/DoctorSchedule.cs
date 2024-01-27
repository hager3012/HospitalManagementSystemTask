using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.PatientModule
{
    public class DoctorSchedule:BaseEntity
    {
        public string Day { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Time { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
