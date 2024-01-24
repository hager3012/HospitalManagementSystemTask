using Hospital_Management_System.ExtiensionMethod;
using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Repository.IdentityData;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

namespace Hospital_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<userDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnectionString")));
            //builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            //    .AddNegotiate();

            //builder.Services.AddAuthorization(options =>
            //{
            //    // By default, all incoming requests will be authorized according to the default policy.
            //    options.FallbackPolicy = options.DefaultPolicy;
            //});
            //builder.Services.AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<userDbContext>();

            builder.Services.AddIdentityServuces(builder.Configuration);
            //builder.Services.AddCors(option =>
            //{
            //    option.AddPolicy("MyPolicy", option =>
            //    {
            //        option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            //    });
            //});
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.MapIdentityApi<AppUser>();
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCors("MyPolicy");
            app.UseAuthentication();
            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
