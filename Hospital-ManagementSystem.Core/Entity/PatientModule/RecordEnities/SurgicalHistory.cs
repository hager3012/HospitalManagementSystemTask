using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities
{
    public class SurgicalHistory : BaseEntity
    {
        public string SurgeryName { get; set; }
        public DateTime DateOfSurgery { get; set; }

    }
}
