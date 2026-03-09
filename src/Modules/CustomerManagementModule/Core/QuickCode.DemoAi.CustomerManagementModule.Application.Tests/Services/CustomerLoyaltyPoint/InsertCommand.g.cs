using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.CustomerManagementModule.Application.Services.CustomerLoyaltyPoint;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.CustomerLoyaltyPoint;
using QuickCode.DemoAi.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Models;

namespace QuickCode.DemoAi.CustomerManagementModule.Application.Tests.Services.CustomerLoyaltyPoint
{
    public class InsertCustomerLoyaltyPointCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ICustomerLoyaltyPointRepository> _repositoryMock;
        private readonly Mock<ILogger<CustomerLoyaltyPointService>> _loggerMock;
        private readonly CustomerLoyaltyPointService _service;
        public InsertCustomerLoyaltyPointCommandTests()
        {
            _repositoryMock = new Mock<ICustomerLoyaltyPointRepository>();
            _loggerMock = new Mock<ILogger<CustomerLoyaltyPointService>>();
            _service = new CustomerLoyaltyPointService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CustomerLoyaltyPointDto>("tr");
            var fakeResponse = new RepoResponse<CustomerLoyaltyPointDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CustomerLoyaltyPointDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<CustomerLoyaltyPointDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CustomerLoyaltyPointDto>("tr");
            var fakeResponse = new RepoResponse<CustomerLoyaltyPointDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CustomerLoyaltyPointDto>())).ReturnsAsync(fakeResponse);
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