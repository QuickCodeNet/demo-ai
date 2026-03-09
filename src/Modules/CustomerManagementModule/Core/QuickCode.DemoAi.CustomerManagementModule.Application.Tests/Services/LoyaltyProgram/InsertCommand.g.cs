using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.CustomerManagementModule.Application.Services.LoyaltyProgram;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.LoyaltyProgram;
using QuickCode.DemoAi.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Models;

namespace QuickCode.DemoAi.CustomerManagementModule.Application.Tests.Services.LoyaltyProgram
{
    public class InsertLoyaltyProgramCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ILoyaltyProgramRepository> _repositoryMock;
        private readonly Mock<ILogger<LoyaltyProgramService>> _loggerMock;
        private readonly LoyaltyProgramService _service;
        public InsertLoyaltyProgramCommandTests()
        {
            _repositoryMock = new Mock<ILoyaltyProgramRepository>();
            _loggerMock = new Mock<ILogger<LoyaltyProgramService>>();
            _service = new LoyaltyProgramService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<LoyaltyProgramDto>("tr");
            var fakeResponse = new RepoResponse<LoyaltyProgramDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<LoyaltyProgramDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<LoyaltyProgramDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<LoyaltyProgramDto>("tr");
            var fakeResponse = new RepoResponse<LoyaltyProgramDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<LoyaltyProgramDto>())).ReturnsAsync(fakeResponse);
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