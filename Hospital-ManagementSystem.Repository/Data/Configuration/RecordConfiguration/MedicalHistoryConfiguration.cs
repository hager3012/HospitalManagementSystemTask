using Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Repository.Data.Configuration.RecordConfiguration
{
    internal class MedicalHistoryConfiguration : IEntityTypeConfiguration<MedicalHistory>
    {
        public void Configure(EntityTypeBuilder<MedicalHistory> builder)
        {
            //builder.OwnsMany(M => M.VitalSigns, M => M.WithOwner());
        }
    }
}
