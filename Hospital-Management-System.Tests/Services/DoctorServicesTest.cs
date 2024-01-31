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
    public class DoctorServicesTest
    {
        public List<Doctor> Doctors { get; set; } = new List<Doctor>
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
        private async Task<DoctorServices> CreateObjectOfPatient(List<Doctor> doctor = null)
        {
            var context = ContextGenerator.Generator();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(doctor);
            await context.SaveChangesAsync();
            var doctorServices = new DoctorServices(context);

            return doctorServices;
        }
        [Fact]
        public async Task GetDoctors_ReturnDoctors()
        {
            //Arrange
            //using var context = ContextGenerator.Generator();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //// Add test data to the in-memory database
            //var doctors = new List<Doctor>
            //{
            //    new Doctor
            //    {
            //        FullName = "John Doe",
            //        Specialization = "Cardiology"
            //    },
            //    new Doctor
            //    {
            //        FullName = "Jane Smith",
            //        Specialization = "Cardiology"
            //    }

            //};
            //context.AddRange(doctors);
            //context.SaveChanges();

            //var doctorServices = new DoctorServices(context);
            var doctorServices = await CreateObjectOfPatient(Doctors);
            // Act
            var result = await doctorServices.GetDoctorsAsync();
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetDoctors_ReturnNoDoctors()
        {
            //Arrange
            using var context = ContextGenerator.Generator(); ;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var doctorServices = new DoctorServices(context);
            // Act
            var result = await doctorServices.GetDoctorsAsync();
            // Assert
            Assert.Empty(result);
        }
        [Fact]
        public async Task GetDoctorSchedules_ReturnDoctorSchedules()
        {
            //Arrange
            using var context = ContextGenerator.Generator();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var doctorSchedule = new DoctorSchedule
            {
                Id = 1,
                Date = new DateOnly(2024, 1, 28),
                Day = "Sunday",
                Time = new TimeSpan(10, 30, 0),
                DoctorId = 1,
                Doctor = new Doctor 
                { 
                    Id = 1,
                    FullName= "John Doe",
                    Specialization = "Cardiology"
                }


            };
            context.AddRange(doctorSchedule);
            context.SaveChanges();

            var doctorServices = new DoctorServices(context);
            //Act
            var result = await doctorServices.GetDoctorSchedulesAsync(1);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetDoctorSchedules_ReturnNullDoctorSchedules()
        {
            //Arrange
            using var context = ContextGenerator.Generator();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var doctorServices = new DoctorServices(context);
            //Act
            var result = await doctorServices.GetDoctorSchedulesAsync(1);
            //Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task GetDoctorSchedules_ReturnNullDoctorSchedules_InvalidDoctorId()
        {
            //Arrange
            using var context = ContextGenerator.Generator();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var doctorSchedule = new DoctorSchedule
            {
                Id = 1,
                Date = new DateOnly(2024, 1, 28),
                Day = "Sunday",
                Time = new TimeSpan(10, 30, 0),
                DoctorId = 1,
                Doctor = new Doctor
                {
                    Id = 1,
                    FullName = "John Doe",
                    Specialization = "Cardiology"
                }


            };
            context.AddRange(doctorSchedule);
            context.SaveChanges();

            var doctorServices = new DoctorServices(context);
            //Act
            var result = await doctorServices.GetDoctorSchedulesAsync(2);
            //Assert
            Assert.Null(result);
        }
    }
}
