using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Services.AppointmentCharge;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.AppointmentCharge;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Models;

namespace QuickCode.DemoAi.AppointmentManagementModule.Application.Tests.Services.AppointmentCharge
{
    public class AppointmentChargeServiceDeleteTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IAppointmentChargeRepository> _repositoryMock;
        private readonly Mock<ILogger<AppointmentChargeService>> _loggerMock;
        private readonly AppointmentChargeService _service;
        public AppointmentChargeServiceDeleteTests()
        {
            _repositoryMock = new Mock<IAppointmentChargeRepository>();
            _loggerMock = new Mock<ILogger<AppointmentChargeService>>();
            _service = new AppointmentChargeService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<AppointmentChargeDto>("tr");
            var fakeGetResponse = new RepoResponse<AppointmentChargeDto>(fakeDto, "Success");
            var fakeDeleteResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<AppointmentChargeDto>())).ReturnsAsync(fakeDeleteResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<AppointmentChargeDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            var fakeDto = TestDataGenerator.CreateFake<AppointmentChargeDto>("tr");
            // Arrange
            var fakeGetResponse = new RepoResponse<AppointmentChargeDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<AppointmentChargeDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}