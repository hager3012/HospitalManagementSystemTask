
using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities;
using Record=Hospital_ManagementSystem.Core.Entity.PatientModule.RecordEnities.Record;
using Hospital_ManagementSystem.Repository.Data;
using Hospital_ManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_ManagementSystem.Core.Entity.PatientModule;

namespace Hospital_Management_System.Tests.Services
{
    public class RecordServicesTests
    {
        public Record Record { get; set; } = new Record
        {
            Id = 1,
            PatientId = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
            DateOfBirth = new DateOnly(2000, 12, 30),
            Gender = "Femal",
            Address = "Cairo",
            Height = 155,
            Weigth = 60,
            PhoneNumber = "01065695783",
            Patient = new Patient
            {
                Id = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                FristName = "Hager",
                LastName = "Shabaan",
                Email = "hagershaaban7@gmail.com"
            },
            MedicalHistory = new MedicalHistory
            {
                SurgicalHistories = new List<SurgicalHistory>
                    {
                        new SurgicalHistory
                        {
                            SurgeryName = "Appendectomy",
                            DateOfSurgery = DateOnly.Parse("2023-01-01")
                        },
                        new SurgicalHistory
                        {
                            SurgeryName = "Knee Surgery",
                            DateOfSurgery = DateOnly.Parse("2022-05-15")
                        }
                    },
                Past_Illnesses = new List<Past_illnesses>
                    {
                        new Past_illnesses
                        {
                            IllnessName = "Flu",
                            DateOfIllness = DateOnly.Parse("2019-01-26"),
                            DurationOfIllness = "2 weeks",
                            FamilyHistory = false
                        },
                        new Past_illnesses
                        {
                            IllnessName = "Allergies",
                            DateOfIllness = DateOnly.Parse("2020-06-20"),
                            DurationOfIllness = "2 days",
                            FamilyHistory = false
                        }
                    },
                VitalSigns = new VitalSigns
                {
                    BloodPressure = "120/80",
                    HeartRate = 75.00M,
                    RespiratoryRate = 18.00M,
                    Temperature = 98.16M
                },
            }
        };
        private static RecordServices RecordServices;
        private async Task<RecordServices> CreateAppointment(Record record = null)
        {
            if (RecordServices is null)
            {
                PatientDbContext context = SetupDatabase();

                context.Add(record);
                await context.SaveChangesAsync();

                RecordServices = new RecordServices(context);
            }


            return RecordServices;
        }

        private static PatientDbContext SetupDatabase()
        {
            var context = ContextGenerator.Generator();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }
        [Fact]
        public async Task ViewRecord_ReturnRecord()
        {
            // Arrange
            var recordServices = await CreateAppointment(Record);

            // Act
            var result = await recordServices.ViewRecord("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7");

                // Assert
                Assert.NotNull(result);
            
        }
        [Fact]
        public async Task ViewRecord_ReturnRecordNull()
        {
            // Arrange
            using var context = ContextGenerator.Generator();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Add test data to the in-memory database
            var record = new Record
            {
                Id = 1,
                PatientId = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                DateOfBirth = new DateOnly(2000, 12, 30),
                Gender = "Femal",
                Address = "Cairo",
                Height = 155,
                Weigth = 60,
                PhoneNumber = "01065695783",
                Patient = new Patient
                {
                    Id = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                    FristName = "Hager",
                    LastName = "Shabaan",
                    Email = "hagershaaban7@gmail.com"
                },
                MedicalHistory = new MedicalHistory
                {
                    SurgicalHistories = new List<SurgicalHistory>
                    {
                        new SurgicalHistory
                        {
                            SurgeryName = "Appendectomy",
                            DateOfSurgery = DateOnly.Parse("2023-01-01")
                        },
                        new SurgicalHistory
                        {
                            SurgeryName = "Knee Surgery",
                            DateOfSurgery = DateOnly.Parse("2022-05-15")
                        }
                    },
                    Past_Illnesses = new List<Past_illnesses>
                    {
                        new Past_illnesses
                        {
                            IllnessName = "Flu",
                            DateOfIllness = DateOnly.Parse("2019-01-26"),
                            DurationOfIllness = "2 weeks",
                            FamilyHistory = false
                        },
                        new Past_illnesses
                        {
                            IllnessName = "Allergies",
                            DateOfIllness = DateOnly.Parse("2020-06-20"),
                            DurationOfIllness = "2 days",
                            FamilyHistory = false
                        }
                    },
                    VitalSigns = new VitalSigns
                    {
                        BloodPressure = "120/80",
                        HeartRate = 75.00M,
                        RespiratoryRate = 18.00M,
                        Temperature = 98.16M
                    },
                }
            };

            context.AddRange(record);
            context.SaveChanges();
            var recordServices = new RecordServices(context);

            // Act
            var result = await recordServices.ViewRecord("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d");

            // Assert
            Assert.Null(result);

        }
    }
}
