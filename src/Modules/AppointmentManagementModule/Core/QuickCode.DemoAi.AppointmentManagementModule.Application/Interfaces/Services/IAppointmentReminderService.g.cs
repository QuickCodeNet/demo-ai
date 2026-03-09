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
    public partial interface IAppointmentReminderService
    {
        Task<Response<AppointmentReminderDto>> InsertAsync(AppointmentReminderDto request);
        Task<Response<bool>> DeleteAsync(AppointmentReminderDto request);
        Task<Response<bool>> UpdateAsync(int id, AppointmentReminderDto request);
        Task<Response<List<AppointmentReminderDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AppointmentReminderDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetUnsentRemindersResponseDto>>> GetUnsentRemindersAsync(bool? appointmentReminderIsSent);
        Task<Response<int>> MarkSentAsync(int appointmentReminderId, MarkSentRequestDto updateRequest);
    }
}