using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Entity.PatientModule;
using Hospital_ManagementSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Tests.Services
{
    public class PatientServicesTest
    {
        public Patient UpdatePatient { get; set; } = new Patient
        {
            Id = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
            FristName = "Hagers",
            LastName = "Shabaan",
            Email = "hagershaaban80@gmail.com"
        };
        public Patient patient { get; set; } = new Patient
        {
            Id = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
            FristName = "Hager",
            LastName = "Shabaan",
            Email = "hagershaaban7@gmail.com"
        };
        private   async Task<PatientServices> CreateObjectOfPatient(Patient patient=null)
        {
             var context = ContextGenerator.Generator();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            context.AddRange(patient);
           await context.SaveChangesAsync();
            var patientServices = new PatientServices(context);

            return patientServices;
        }
        [Fact]
        public async Task UpdatePatientInfo_ReturnOne()
        {
            //Arrange
            var patientServices =await CreateObjectOfPatient(patient);
    
            // Act
            var result = await patientServices.UpdatePatientInfoAsync("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7", UpdatePatient);
            // Assert
            Assert.Equal(1,result);

        }
        [Fact]
        public async Task UpdatePatientInfo_ReturnZero()
        {
            //Arrange
            var patientServices =await CreateObjectOfPatient(patient);
            // Act
            var result = await patientServices.UpdatePatientInfoAsync("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d", UpdatePatient);
            // Assert
            Assert.Equal(0, result);
        }
        [Fact]
        public async Task GetPatientInfo_ReturnPatientInfo()
        {
            //Arrange
            var patientServices =await CreateObjectOfPatient(patient);
            
            // Act
            var result = await patientServices.GetPatientInfoAsync("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7");
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetPatientInfo_ReturnNull()
        {
            //Arrange
            var patientServices =await CreateObjectOfPatient(patient);
            // Act
            var result = await patientServices.GetPatientInfoAsync("26c9e7dc-fb7c-4084-af5f-9e5ccfb5");
            // Assert
            Assert.Null(result);
        }
    }
}
