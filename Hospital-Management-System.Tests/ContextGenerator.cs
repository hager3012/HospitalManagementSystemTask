using Hospital_ManagementSystem.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Tests
{
    public static class ContextGenerator
    {
        public static PatientDbContext Generator()
        {
            var options = new DbContextOptionsBuilder<PatientDbContext>()
                .UseInMemoryDatabase(databaseName: "HospitalManagementSystem")
                .Options;
            return new PatientDbContext(options);
        }
    }
}
