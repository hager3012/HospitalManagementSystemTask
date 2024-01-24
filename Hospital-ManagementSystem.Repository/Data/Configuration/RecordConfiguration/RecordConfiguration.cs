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
    internal class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.Property(R => R.width).HasColumnType("decimal(18,2)");
            builder.HasOne(R => R.MedicalHistory).WithOne(M => M.Record).HasForeignKey<MedicalHistory>(M => M.RecordId).IsRequired();
            
        }
    }
}
