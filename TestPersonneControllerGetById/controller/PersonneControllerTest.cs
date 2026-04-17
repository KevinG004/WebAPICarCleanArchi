using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using CarApiClean.Controllers;
using CarList.Core.Interfaces.Services.Data;
using CarList.Core.DTOs.Responses;

namespace TestPersonneControllerGetById.controller
{
    public class PersonneControllerTest
    {
        private readonly Mock<IPersonneService> _mockService;
        private readonly PersonnesController _controller;

        public PersonneControllerTest()
        {
            _mockService = new Mock<IPersonneService>();
            _controller = new PersonnesController(_mockService.Object);
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenPersonneExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var fakePersonne = new PersonneAddResponseDTO
            {
                Email = "test@test.com",
                FirstName = "John",
                Password = "password123",
                LastName = "Doe",
                Cars = null
            };

            _mockService
                .Setup(s => s.GetById(id))
                .ReturnsAsync(fakePersonne);

            // Act
            var result = await _controller.Get(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(fakePersonne, okResult.Value);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenPersonneDoesNotExist()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockService
                .Setup(s => s.GetById(id))
                .ReturnsAsync((PersonneAddResponseDTO?)null);

            // Act
            var result = await _controller.Get(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
