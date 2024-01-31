using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Entity.PatientModule;
using Hospital_ManagementSystem.Core.Services.Contract;
using Hospital_ManagementSystem.Repository.Data;
using Hospital_ManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Tests.Services
{
    public class AppointmentServicesTest
    {
        int numberForCheck = 0;
        
        public List<Appointment> Appointments { get; set; } = new List<Appointment>()
             {
                new Appointment()
                {
                    Id = 1,
                    Date = new DateOnly(2024, 1, 26),
                    DoctorId = 1,
                    Time = TimeSpan.FromHours(14),
                    PatientId = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                    Doctor = new Doctor
                    {
                        FullName= "John Doe",
                        Specialization= "Cardiology"
                    }
                },
                new Appointment()
                {
                    Id = 2,
                    Date = new DateOnly(2024, 1, 26),
                    DoctorId = 1,
                    Time = TimeSpan.FromHours(14),
                    PatientId = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                    Doctor = new Doctor
                    {
                        FullName= "John Doe",
                        Specialization= "Cardiology"
                    }
                }
        };
        public Appointment Appointment { get; set; } = new Appointment
        {
            Id = 3,
            Date = new DateOnly(2024, 1, 26),
            DoctorId = 1,
            Time = TimeSpan.FromHours(14),
            PatientId = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
            Doctor = new Doctor
            {
                FullName = "John Doe",
                Specialization = "Cardiology"
            }
        };
        private static  AppointmentServices AppointmentServices;
        private async Task<AppointmentServices> CreateAppointment(List<Appointment> appointment = null)
        {
            if (AppointmentServices is null)
            {
                PatientDbContext context = SetupDatabase();

                context.AddRange(appointment);
                await context.SaveChangesAsync();

                AppointmentServices = new AppointmentServices(context);
            }


            return AppointmentServices;
        }

        private static PatientDbContext SetupDatabase()
        {
            var context = ContextGenerator.Generator();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task BookAppointment_ReturnOne()
        {
            //Arrange
            var appointmentServices = await CreateAppointment(Appointments);
            // Act
            var result = await appointmentServices.BookAppointment("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7", Appointment);
            // Assert
            Assert.True( result>numberForCheck);
        }
        [Fact]
        public async Task GetAppointments_ReturnAppointments()
        {
            //Arrange
            var appointmentServices = await CreateAppointment(Appointments);

            // Act
            var result = await appointmentServices.GetAppointments("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7");
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetAppointments_ReturnNullAppointments()
        {
            //Arrange
            var appointmentServices = await CreateAppointment(Appointments);

            // Act
            var result = await appointmentServices.GetAppointments("26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7");
            // Assert
            Assert.Empty(result);
        }
        [Fact]
        public async Task CancelAppointment_ReturnOne()
        {
            //Arrange
            using var context = ContextGenerator.Generator(); ;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var appointmentServices = new AppointmentServices(context);
            var appointment =new Appointment
                {
                    Id = 2,
                    Date = new DateOnly(2024, 1, 26),
                    DoctorId = 1,
                    Time = TimeSpan.FromHours(14),
                    PatientId = "26c9e7dc-fb7c-4084-af5f-9e5ccfb5d5b7",
                    Doctor = new Doctor
                    {
                        FullName = "John Doe",
                        Specialization = "Cardiology"
                    }
                };
            context.AddRange(appointment);
            context.SaveChanges();
            // Act
            var result = await appointmentServices.CancelAppointment(2);
            // Assert
            Assert.Equal(1,result);
        }
    }
}
