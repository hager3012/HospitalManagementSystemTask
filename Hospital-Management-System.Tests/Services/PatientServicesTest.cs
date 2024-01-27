using Hospital_ManagementSystem.Core.Entity.Identity;
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
        public async Task UpdatePatientInfo_ReturnOne()
        {
            //Arrange
            using var context = ContextGenerator.Generator(); ;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var patientServices = new PatientServices(context);
            var Patient = new Patient
            {
                Id = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                FristName = "Hager",
                LastName = "Shabaan",
                Email = "hagershaaban7@gmail.com"
            };
            var PatientUpdated = new Patient
            {
                Id = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                FristName = "Hagers",
                LastName = "Shabaan",
                Email = "hagershaaban80@gmail.com"
            };
            context.AddRange(Patient);
            context.SaveChanges();
            // Act
            var result = await patientServices.UpdatePatientInfoAsync("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7", PatientUpdated);
            // Assert
            Assert.Equal(1,result);
        }
        [Fact]
        public async Task UpdatePatientInfo_ReturnZero()
        {
            //Arrange
            using var context = ContextGenerator.Generator(); ;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var patientServices = new PatientServices(context);
            var Patient = new Patient
            {
                Id = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                FristName = "Hager",
                LastName = "Shabaan",
                Email = "hagershaaban7@gmail.com"
            };
            var PatientUpdated = new Patient
            {
                Id = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                FristName = "Hagers",
                LastName = "Shabaan",
                Email = "hagershaaban80@gmail.com"
            };
            context.AddRange(Patient);
            context.SaveChanges();
            // Act
            var result = await patientServices.UpdatePatientInfoAsync("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d", PatientUpdated);
            // Assert
            Assert.Equal(0, result);
        }
        [Fact]
        public async Task GetPatientInfo_ReturnPatientInfo()
        {
            //Arrange
            using var context = ContextGenerator.Generator(); ;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var patientServices = new PatientServices(context);
            var Patient = new Patient
            {
                Id = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                FristName = "Hager",
                LastName = "Shabaan",
                Email = "hagershaaban7@gmail.com"
            };
            context.AddRange(Patient);
            context.SaveChanges();
            // Act
            var result = await patientServices.GetPatientInfoAsync("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7");
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetPatientInfo_ReturnNull()
        {
            //Arrange
            using var context = ContextGenerator.Generator(); ;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var patientServices = new PatientServices(context);
            // Act
            var result = await patientServices.GetPatientInfoAsync("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7");
            // Assert
            Assert.Null(result);
        }
    }
}
