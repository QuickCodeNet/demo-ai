using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.CustomerManagementModule.Application.Services.CustomerAddress;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.CustomerAddress;
using QuickCode.DemoAi.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Models;

namespace QuickCode.DemoAi.CustomerManagementModule.Application.Tests.Services.CustomerAddress
{
    public class InsertCustomerAddressCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ICustomerAddressRepository> _repositoryMock;
        private readonly Mock<ILogger<CustomerAddressService>> _loggerMock;
        private readonly CustomerAddressService _service;
        public InsertCustomerAddressCommandTests()
        {
            _repositoryMock = new Mock<ICustomerAddressRepository>();
            _loggerMock = new Mock<ILogger<CustomerAddressService>>();
            _service = new CustomerAddressService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CustomerAddressDto>("tr");
            var fakeResponse = new RepoResponse<CustomerAddressDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CustomerAddressDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<CustomerAddressDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CustomerAddressDto>("tr");
            var fakeResponse = new RepoResponse<CustomerAddressDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CustomerAddressDto>())).ReturnsAsync(fakeResponse);
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