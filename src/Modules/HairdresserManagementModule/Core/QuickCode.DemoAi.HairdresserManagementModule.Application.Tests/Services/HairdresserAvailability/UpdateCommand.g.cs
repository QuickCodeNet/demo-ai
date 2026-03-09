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
    public class UpdateHairdresserAvailabilityCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IHairdresserAvailabilityRepository> _repositoryMock;
        private readonly Mock<ILogger<HairdresserAvailabilityService>> _loggerMock;
        private readonly HairdresserAvailabilityService _service;
        public UpdateHairdresserAvailabilityCommandTests()
        {
            _repositoryMock = new Mock<IHairdresserAvailabilityRepository>();
            _loggerMock = new Mock<ILogger<HairdresserAvailabilityService>>();
            _service = new HairdresserAvailabilityService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<HairdresserAvailabilityDto>("tr");
            var fakeGetResponse = new RepoResponse<HairdresserAvailabilityDto>(fakeDto, "Success");
            var fakeUpdateResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<HairdresserAvailabilityDto>())).ReturnsAsync(fakeUpdateResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.Id, fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<HairdresserAvailabilityDto>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<HairdresserAvailabilityDto>("tr");
            var fakeGetResponse = new RepoResponse<HairdresserAvailabilityDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.Id, fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<HairdresserAvailabilityDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}