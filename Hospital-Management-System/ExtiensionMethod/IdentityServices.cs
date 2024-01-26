using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Core.Services.Contract;
using Hospital_ManagementSystem.Repository.Data;
using Hospital_ManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;

namespace Hospital_Management_System.ExtiensionMethod
{
    public static class IdentityServices
    {
        /// <summary>
        /// Extension Method for Adds services for controllers to the specified <see cref="IServiceCollection"/>. This method will not
        /// register services used for identity services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/>to add configuration to.</param>
        /// <returns>An <see cref="IServiceCollection"/> that can be used to further configure the App services.</returns>
        public static IServiceCollection AddIdentityServuces(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddIdentity<Patient,IdentityRole>().AddEntityFrameworkStores<PatientDbContext>();
            services.AddScoped(typeof(IAuthServices), typeof(AuthServices));
            return services;    
        }
    }
}
