using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.PatientModule
{
    public class Doctor:BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<DoctorSchedule> Schedules { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
