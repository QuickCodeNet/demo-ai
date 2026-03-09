using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Services.HairdresserAvailability;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.HairdresserAvailability;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Models;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Tests.Services.HairdresserAvailability
{
    public class InsertHairdresserAvailabilityCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IHairdresserAvailabilityRepository> _repositoryMock;
        private readonly Mock<ILogger<HairdresserAvailabilityService>> _loggerMock;
        private readonly HairdresserAvailabilityService _service;
        public InsertHairdresserAvailabilityCommandTests()
        {
            _repositoryMock = new Mock<IHairdresserAvailabilityRepository>();
            _loggerMock = new Mock<ILogger<HairdresserAvailabilityService>>();
            _service = new HairdresserAvailabilityService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<HairdresserAvailabilityDto>("tr");
            var fakeResponse = new RepoResponse<HairdresserAvailabilityDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<HairdresserAvailabilityDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<HairdresserAvailabilityDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<HairdresserAvailabilityDto>("tr");
            var fakeResponse = new RepoResponse<HairdresserAvailabilityDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<HairdresserAvailabilityDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.Null(result.Value);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}