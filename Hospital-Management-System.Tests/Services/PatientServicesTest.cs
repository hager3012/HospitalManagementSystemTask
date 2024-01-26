using Hospital_ManagementSystem.Core.Entity.PatientModule;
using Hospital_ManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Tests.Services
{
    public class PatientServicesTest
    {
        [Fact]
        public async Task GetDoctors_ReturnDoctors()
        {
            //Arrange
            using var context = ContextGenerator.Generator();
            // Add test data to the in-memory database
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    FullName = "John Doe",
                    Specialization = "Cardiology"
                },
                new Doctor
                {
                    FullName = "Jane Smith",
                    Specialization = "Cardiology"
                }

            };
            context.AddRange(doctors);
            context.SaveChanges();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var patientServices = new PatientServices(context);
            // Act
            var result = await patientServices.GetDoctorsAsync();
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetDoctors_ReturnNoDoctors()
        {
            //Arrange
            using var context = ContextGenerator.Generator();;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var patientServices = new PatientServices(context);
            // Act
            var result = await patientServices.GetDoctorsAsync();
            // Assert
            Assert.Empty(result);
        }
    }
}
