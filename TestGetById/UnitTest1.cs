using CarApiClean.Controllers;
using CarList.Core.DTOs.Responses;
using CarList.Core.Interfaces.Services.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace TestGetById
{
    public class PersonnesControllerGetByIdTests
    {
        private readonly Mock<IPersonneService> _mockService;
        private readonly PersonnesController _controller;

        public PersonnesControllerGetByIdTests()
        {
            _mockService = new Mock<IPersonneService>();
            _controller = new PersonnesController(_mockService.Object);
        }

        [Fact]
        public async Task GetById_PersonneExiste_RetourneOkAvecPersonne()
        {
            // Arrange
            var id = Guid.NewGuid();
            var personneAttendue = new PersonneAddResponseDTO
            {
                Email = "test@example.com",
                Password = "secret",
                FirstName = "Jean",
                LastName = "Dupont"
            };
            _mockService
                .Setup(s => s.GetById(id))
                .ReturnsAsync(personneAttendue);

            // Act
            var result = await _controller.Get(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(personneAttendue, okResult.Value);
        }

        [Fact]
        public async Task GetById_PersonneInexistante_RetourneNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockService
                .Setup(s => s.GetById(id))
                .ReturnsAsync((PersonneAddResponseDTO?)null);

            // Act
            var result = await _controller.Get(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task GetById_AppelleServiceAvecBonId()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockService
                .Setup(s => s.GetById(id))
                .ReturnsAsync((PersonneAddResponseDTO?)null);

            // Act
            await _controller.Get(id);

            // Assert — vérifie que le service a été appelé exactement une fois avec le bon id
            _mockService.Verify(s => s.GetById(id), Times.Once);
        }
    }
}
