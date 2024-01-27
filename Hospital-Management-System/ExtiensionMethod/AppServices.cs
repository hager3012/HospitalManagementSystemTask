using Hospital_Management_System.Helper;
using Hospital_ManagementSystem.Core.Services.Contract;
using Hospital_ManagementSystem.Services;

namespace Hospital_Management_System.ExtiensionMethod
{
    public static class AppServices
    {
        /// <summary>
        /// Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
        /// register services used for App services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>An <see cref="IServiceCollection"/> that can be used to further configure the App services.</returns>
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRecordServices), typeof(RecordServices));
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped(typeof(IPatientServices), typeof(PatientServices));
            services.AddScoped(typeof(IDoctorServices), typeof(DoctorServices));
            services.AddScoped(typeof(IAppointmentServices), typeof(AppointmentServices));
            return services;
        }
    }
}
