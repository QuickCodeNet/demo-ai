using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Services.ServicePrice;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.ServicePrice;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Models;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Tests.Services.ServicePrice
{
    public class InsertServicePriceCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IServicePriceRepository> _repositoryMock;
        private readonly Mock<ILogger<ServicePriceService>> _loggerMock;
        private readonly ServicePriceService _service;
        public InsertServicePriceCommandTests()
        {
            _repositoryMock = new Mock<IServicePriceRepository>();
            _loggerMock = new Mock<ILogger<ServicePriceService>>();
            _service = new ServicePriceService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ServicePriceDto>("tr");
            var fakeResponse = new RepoResponse<ServicePriceDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<ServicePriceDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<ServicePriceDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ServicePriceDto>("tr");
            var fakeResponse = new RepoResponse<ServicePriceDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<ServicePriceDto>())).ReturnsAsync(fakeResponse);
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