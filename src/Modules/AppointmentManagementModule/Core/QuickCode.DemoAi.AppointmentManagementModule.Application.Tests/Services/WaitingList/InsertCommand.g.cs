using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Services.WaitingList;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.WaitingList;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Models;

namespace QuickCode.DemoAi.AppointmentManagementModule.Application.Tests.Services.WaitingList
{
    public class InsertWaitingListCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IWaitingListRepository> _repositoryMock;
        private readonly Mock<ILogger<WaitingListService>> _loggerMock;
        private readonly WaitingListService _service;
        public InsertWaitingListCommandTests()
        {
            _repositoryMock = new Mock<IWaitingListRepository>();
            _loggerMock = new Mock<ILogger<WaitingListService>>();
            _service = new WaitingListService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<WaitingListDto>("tr");
            var fakeResponse = new RepoResponse<WaitingListDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<WaitingListDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<WaitingListDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<WaitingListDto>("tr");
            var fakeResponse = new RepoResponse<WaitingListDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<WaitingListDto>())).ReturnsAsync(fakeResponse);
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