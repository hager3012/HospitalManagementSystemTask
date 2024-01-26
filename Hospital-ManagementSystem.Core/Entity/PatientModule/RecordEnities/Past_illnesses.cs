﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities
{
    public class Past_illnesses : BaseEntity
    {
        public string IllnessName { get; set; }
        public DateOnly DateOfIllness { get; set; }
        public string DurationOfIllness { get; set; }
        public bool FamilyHistory { get; set; }
    }
}
