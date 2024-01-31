using Hospital_ManagementSystem.Core.Entity.PatientModule;
using Hospital_ManagementSystem.Repository.Data;
using Hospital_ManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Tests.Services
{
    public class PrescriptionServicesTest
    {
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>
        {
                new Prescription
                {
                    MedicationName = "Test",
                    MedicationDescription = "Test",
                    PatientId= "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7"
                },
                new Prescription
                {
                    MedicationName = "Test",
                    MedicationDescription = "Test",
                    PatientId= "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7"
                },
        };
        private static PrescriptionServices PrescriptionServices;
        private async Task<PrescriptionServices> CreatePrescriptionService(List<Prescription> prescriptions = null)
        {
            if (PrescriptionServices is null)
            {
                PatientDbContext context = SetupDatabase();

                context.AddRange(prescriptions);
                await context.SaveChangesAsync();

                PrescriptionServices = new PrescriptionServices(context);
            }


            return PrescriptionServices;
        }

        private static PatientDbContext SetupDatabase()
        {
            var context = ContextGenerator.Generator();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }
        [Fact]
        public async Task GetAllPrescription_ReturnPrescription()
        {
            //Arrange
            var prescriptionServices = await CreatePrescriptionService(Prescriptions);
            //Act
            var result = await prescriptionServices.GetAllPrescriptionsForPatient("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7");
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetAllPrescription_ReturnEmptyPrescriptions()
        {
            //Arrange
            var prescriptionServices = await CreatePrescriptionService(Prescriptions);
            //Act
            var result = await prescriptionServices.GetAllPrescriptionsForPatient("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5");
            //Assert
            Assert.Empty(result);
        }
        [Fact]
        public async Task GetPrescriptionDetails_ReturnPrescription()
        {
            //Arrange
            using var context = ContextGenerator.Generator();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var prescription = new Prescription
            {
                MedicationName = "Test",
                MedicationDescription = "Test",
                PatientId = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                DoctorId = 1,
                Doctor = new Doctor
                {
                    Id = 1,
                    FullName = "Test",
                    Specialization="smkn"
                }
            };
            context.AddRange(prescription);
            context.SaveChanges();

            var prescriptionServices = new PrescriptionServices(context);
            //Act
            var result = await prescriptionServices.GetPrescription("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",1);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetPrescriptionDetails_ReturnNullPrescription()
        {
            //Arrange
            using var context = ContextGenerator.Generator();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var prescription = new Prescription
            {
                MedicationName = "Test",
                MedicationDescription = "Test",
                PatientId = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                DoctorId = 1,
                Doctor = new Doctor
                {
                    Id = 1,
                    FullName = "Test",
                    Specialization = "smkn"
                }
            };
            context.AddRange(prescription);
            context.SaveChanges();

            var prescriptionServices = new PrescriptionServices(context);
            //Act
            var result = await prescriptionServices.GetPrescription("26c9e7dc-fb7c-4084-af5f-9e5cc", 1);
            //Assert
            Assert.Null(result);
        }
    }
}
