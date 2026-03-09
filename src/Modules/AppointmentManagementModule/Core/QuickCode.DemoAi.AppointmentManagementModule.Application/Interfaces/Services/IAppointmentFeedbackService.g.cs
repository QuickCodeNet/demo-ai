using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.AppointmentFeedback;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Application.Services.AppointmentFeedback
{
    public partial interface IAppointmentFeedbackService
    {
        Task<Response<AppointmentFeedbackDto>> InsertAsync(AppointmentFeedbackDto request);
        Task<Response<bool>> DeleteAsync(AppointmentFeedbackDto request);
        Task<Response<bool>> UpdateAsync(int id, AppointmentFeedbackDto request);
        Task<Response<List<AppointmentFeedbackDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AppointmentFeedbackDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<GetByAppointmentIdResponseDto>> GetByAppointmentIdAsync(int appointmentFeedbackAppointmentId);
    }
}