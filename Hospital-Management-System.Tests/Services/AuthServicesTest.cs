using Hospital_ManagementSystem.Core.Entity.Identity;
using Hospital_ManagementSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Tests.Services
{
    public class AuthServicesTest
    {
        [Fact]
        public async Task CreateTokenAsync_ShouldGenerateToken()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["TokenString:TokenKey"]).Returns(Convert.ToBase64String(Guid.NewGuid().ToByteArray()));
            configuration.Setup(x => x["TokenString:Audience"]).Returns("testAudience");

            var userManager = new Mock<UserManager<Patient>>(
                new Mock<IUserStore<Patient>>().Object,
                null, null, null, null, null, null, null, null);

            var authService = new AuthServices(configuration.Object);

            var user = new Patient
            {
                Id = "userId",
                UserName = "testuser",
                Email = "testuser@example.com"
            };

            userManager.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(new List<string> { "UserRole1", "UserRole2" });

            // Act
            var token = await authService.CreateTokenAsync(user, userManager.Object);

            // Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }
    }
}
