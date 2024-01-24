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
        /// Extension Method for IServicesCollection for add Identity functionalities 
        /// </summary>
        /// <param name="builder.Configuration">An instance of the configuration.</param>
        /// <returns>An instance of the services</returns>
        public static IServiceCollection AddIdentityServuces(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddIdentity<Patient,IdentityRole>().AddEntityFrameworkStores<PatientDbContext>();
            services.AddScoped(typeof(IAuthServices), typeof(AuthServices));
            //services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
            //services.AddAuthorization(options =>
            //{
            //    // By default, all incoming requests will be authorized according to the default policy.
            //    options.FallbackPolicy = options.DefaultPolicy;

            //});
            return services;    
        }
    }
}
