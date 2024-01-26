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
    internal class VitalSignsConfiguration : IEntityTypeConfiguration<VitalSigns>
    {
        public void Configure(EntityTypeBuilder<VitalSigns> builder)
        {
            builder.Property(V => V.Temperature).HasColumnType("decimal(18,2)");
            builder.Property(V => V.RespiratoryRate).HasColumnType("decimal(18,2)");
            builder.Property(V => V.HeartRate).HasColumnType("decimal(18,2)");
        }
    }
}
