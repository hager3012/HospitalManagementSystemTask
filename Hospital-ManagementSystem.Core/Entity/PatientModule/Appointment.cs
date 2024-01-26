using Hospital_ManagementSystem.Core.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.PatientModule
{
    public class Appointment:BaseEntity
    {
        public Doctor Doctor{ get; set; }
        public DateOnly DateAndTime { get; set; }
        public Patient  Patient { get; set; }
    }
}
