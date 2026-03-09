using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Services.HairdresserNote;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.HairdresserNote;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Models;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Tests.Services.HairdresserNote
{
    public class InsertHairdresserNoteCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IHairdresserNoteRepository> _repositoryMock;
        private readonly Mock<ILogger<HairdresserNoteService>> _loggerMock;
        private readonly HairdresserNoteService _service;
        public InsertHairdresserNoteCommandTests()
        {
            _repositoryMock = new Mock<IHairdresserNoteRepository>();
            _loggerMock = new Mock<ILogger<HairdresserNoteService>>();
            _service = new HairdresserNoteService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<HairdresserNoteDto>("tr");
            var fakeResponse = new RepoResponse<HairdresserNoteDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<HairdresserNoteDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<HairdresserNoteDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<HairdresserNoteDto>("tr");
            var fakeResponse = new RepoResponse<HairdresserNoteDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<HairdresserNoteDto>())).ReturnsAsync(fakeResponse);
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