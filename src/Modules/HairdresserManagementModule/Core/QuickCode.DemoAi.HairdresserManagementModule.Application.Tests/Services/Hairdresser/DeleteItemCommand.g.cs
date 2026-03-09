using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Services.Hairdresser;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.Hairdresser;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Models;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Tests.Services.Hairdresser
{
    public class HairdresserServiceDeleteTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IHairdresserRepository> _repositoryMock;
        private readonly Mock<ILogger<HairdresserService>> _loggerMock;
        private readonly HairdresserService _service;
        public HairdresserServiceDeleteTests()
        {
            _repositoryMock = new Mock<IHairdresserRepository>();
            _loggerMock = new Mock<ILogger<HairdresserService>>();
            _service = new HairdresserService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<HairdresserDto>("tr");
            var fakeGetResponse = new RepoResponse<HairdresserDto>(fakeDto, "Success");
            var fakeDeleteResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<HairdresserDto>())).ReturnsAsync(fakeDeleteResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<HairdresserDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            var fakeDto = TestDataGenerator.CreateFake<HairdresserDto>("tr");
            // Arrange
            var fakeGetResponse = new RepoResponse<HairdresserDto>
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
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<HairdresserDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}