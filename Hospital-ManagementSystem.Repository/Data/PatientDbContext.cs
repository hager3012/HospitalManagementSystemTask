using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Entity.PatientModule;
using Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_ManagementSystem.Repository.Data
{
    public class PatientDbContext:IdentityDbContext<Patient>
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> dbContext):base(dbContext)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Record> Records { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Past_illnesses> Past_Illnesses { get; set; }
        public DbSet<SurgicalHistory> SurgicalHistories { get; set; }
        public DbSet<VitalSigns> VitalSigns { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}
