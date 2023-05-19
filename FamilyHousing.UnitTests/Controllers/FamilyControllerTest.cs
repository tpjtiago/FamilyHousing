using FamilyHousing.API.Controllers;
using FamilyHousing.Domain.Contracts.Services;
using FamilyHousing.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FamilyHousing.UnitTests.Controllers
{

    public class FamilyControllerTest
    {
        [Fact]
        public async Task GetListEligibleFamilies_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IFamilyService>();
            var controller = new FamilyController(mockService.Object);

            var expectedModel = new List<FamilyModel>(); 
            mockService.Setup(service => service.GetListEligibleFamilies())
                       .ReturnsAsync(expectedModel);

            // Act
            var result = await controller.GetListEligibleFamilies();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualModel = Assert.IsAssignableFrom<List<FamilyModel>>(okResult.Value);
            Assert.Equal(expectedModel, actualModel);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IFamilyService>();
            var controller = new FamilyController(mockService.Object);

            var family = new FamilyModel(); 
            var id = 1; 

            mockService.Setup(service => service.GetbyId(id))
                       .ReturnsAsync(family);

            // Act
            var result = await controller.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualModel = Assert.IsAssignableFrom<FamilyModel>(okResult.Value);
            Assert.Equal(family, actualModel);
        }

        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IFamilyService>();
            var controller = new FamilyController(mockService.Object);

            var families = new List<FamilyModel>();

            mockService.Setup(service => service.GetAll())
                       .ReturnsAsync(families);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualModel = Assert.IsAssignableFrom<List<FamilyModel>>(okResult.Value);
            Assert.Equal(families, actualModel);
        }

    }
}
