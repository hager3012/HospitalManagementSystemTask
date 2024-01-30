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
        private static PatientDbContext Context;
        public static PatientDbContext Generator()
        {
            if(Context == null)
            {
                var options = new DbContextOptionsBuilder<PatientDbContext>()
               .UseInMemoryDatabase(databaseName: "HospitalManagementSystem")
               .Options;
                Context = new PatientDbContext(options);
            }
           
            return Context;
        }
    }
}
