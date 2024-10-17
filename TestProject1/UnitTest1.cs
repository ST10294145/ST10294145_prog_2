using Microsoft.AspNetCore.Mvc;
using Moq;
using ST10294145_prog_2.Controllers;
using ST10294145_prog_2.Models;
using Xunit;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Http;

namespace Testroject1
{
    public class ClaimsControllerTests
    {
        [Fact]
        public void Dashboard_ReturnsView_WithClaims_ForLecturer()
        {
            // Arrange
            var mockHttpContext = new Mock<HttpContext>();
            var mockSession = new Mock<ISession>();
            mockSession.Setup(s => s.GetString("UserRole")).Returns("Lecturer");

            mockHttpContext.Setup(h => h.Session).Returns(mockSession.Object);

            var claimsController = new ClaimsController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = mockHttpContext.Object
                }
            };

            // Add some sample claims data to simulate data retrieval
            InMemoryData.Claims = new List<Claim>
            {
                new Claim { Id = 1, LecturerName = "lecturer", HoursWorked = 5, HourlyRate = 50, Status = "Pending", SupportingDocument = "doc1.pdf" },
                new Claim { Id = 2, LecturerName = "lecturer", HoursWorked = 10, HourlyRate = 45, Status = "Approved", SupportingDocument = "doc2.pdf" }
            };

            // Act
            var result = claimsController.Dashboard() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<List<Claim>>(result.Model);
            Assert.Equal(2, model.Count);  // Verifying that two claims are passed
        }

        [Fact]
        public void Dashboard_RedirectsToHome_WhenUserRoleIsNull()
        {
            // Arrange
            var mockHttpContext = new Mock<HttpContext>();
            var mockSession = new Mock<ISession>();
            mockSession.Setup(s => s.GetString("UserRole")).Returns((string)null);

            mockHttpContext.Setup(h => h.Session).Returns(mockSession.Object);

            var claimsController = new ClaimsController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = mockHttpContext.Object
                }
            };

            // Act
            var result = claimsController.Dashboard() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }
    }
}
