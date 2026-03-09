using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Services.AppointmentReminder;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.AppointmentReminder;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Models;

namespace QuickCode.DemoAi.AppointmentManagementModule.Application.Tests.Services.AppointmentReminder
{
    public class InsertAppointmentReminderCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IAppointmentReminderRepository> _repositoryMock;
        private readonly Mock<ILogger<AppointmentReminderService>> _loggerMock;
        private readonly AppointmentReminderService _service;
        public InsertAppointmentReminderCommandTests()
        {
            _repositoryMock = new Mock<IAppointmentReminderRepository>();
            _loggerMock = new Mock<ILogger<AppointmentReminderService>>();
            _service = new AppointmentReminderService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<AppointmentReminderDto>("tr");
            var fakeResponse = new RepoResponse<AppointmentReminderDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<AppointmentReminderDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<AppointmentReminderDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<AppointmentReminderDto>("tr");
            var fakeResponse = new RepoResponse<AppointmentReminderDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<AppointmentReminderDto>())).ReturnsAsync(fakeResponse);
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