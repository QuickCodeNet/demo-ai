using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.AppointmentReminder;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Application.Services.AppointmentReminder
{
    public partial class AppointmentReminderService : IAppointmentReminderService
    {
        private readonly ILogger<AppointmentReminderService> _logger;
        private readonly IAppointmentReminderRepository _repository;
        public AppointmentReminderService(ILogger<AppointmentReminderService> logger, IAppointmentReminderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AppointmentReminderDto>> InsertAsync(AppointmentReminderDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AppointmentReminderDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AppointmentReminderDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AppointmentReminderDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AppointmentReminderDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetUnsentRemindersResponseDto>>> GetUnsentRemindersAsync(bool? appointmentReminderIsSent)
        {
            var returnValue = await _repository.GetUnsentRemindersAsync(appointmentReminderIsSent);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> MarkSentAsync(int appointmentReminderId, MarkSentRequestDto updateRequest)
        {
            var returnValue = await _repository.MarkSentAsync(appointmentReminderId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}