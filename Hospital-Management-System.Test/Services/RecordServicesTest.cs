using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Repository.Data;
using Hospital_ManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Test.Services
{
    public class RecordServicesTest
    {
        [Fact]
        public async Task ViewRecord_ValidPatientId_ReturnsRecord()
        {
            //Arrange
           var options = new DbContextOptionsBuilder<PatientDbContext>()
               .UseInMemoryDatabase(databaseName: "HospitalManagementSystem")
               .Options;

            using var dbContext = new PatientDbContext(options);
            // Delete existing db before creating a new one
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            // Add test data to the in-memory database
            // This will depend on your specific data model and requirements

            var recordServices = new RecordServices(dbContext);

            // Act
            var result = await recordServices.ViewRecord("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7");
            //var IdPatient = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7";
            Console.WriteLine($"Result: {result}");
            // Assert
            //Assert.NotNull(result);
            // Add more assertions based on your expected result

            //var options = new DbContextOptionsBuilder<PatientDbContext>()
            //.UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            //.Options;

            //using (var context = new PatientDbContext(options))
            //{
            //    // Add test data to the in-memory database
            //    // This could involve adding a patient, a record, medical history, etc.
            //    // Ensure that the data in the database matches what you expect in your test
            //    // ...

            //    var recordServices = new RecordServices(context);

            //    // Act
            //    var result = await recordServices.ViewRecord("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7");

            //    // Assert
            //    Assert.NotNull(result);
            //    // Add more assertions based on your expected results
            //}

        }

    }
}
