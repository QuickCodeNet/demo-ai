using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.Appointment;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Application.Services.Appointment
{
    public partial interface IAppointmentService
    {
        Task<Response<AppointmentDto>> InsertAsync(AppointmentDto request);
        Task<Response<bool>> DeleteAsync(AppointmentDto request);
        Task<Response<bool>> UpdateAsync(int id, AppointmentDto request);
        Task<Response<List<AppointmentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AppointmentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int appointmentCustomerId, int? page, int? size);
        Task<Response<List<GetByServiceIdResponseDto>>> GetByServiceIdAsync(int appointmentServiceId, int? page, int? size);
        Task<Response<List<GetByDateRangeResponseDto>>> GetByDateRangeAsync(DateTime appointmentAppointmentDateFrom, DateTime appointmentAppointmentDateTo, int? page, int? size);
        Task<Response<List<GetAppointmentFeedbacksForAppointmentsResponseDto>>> GetAppointmentFeedbacksForAppointmentsAsync(int appointmentsId);
        Task<Response<GetAppointmentFeedbacksForAppointmentsResponseDto>> GetAppointmentFeedbacksForAppointmentsDetailsAsync(int appointmentsId, int appointmentFeedbacksId);
        Task<Response<List<GetAppointmentRemindersForAppointmentsResponseDto>>> GetAppointmentRemindersForAppointmentsAsync(int appointmentsId);
        Task<Response<GetAppointmentRemindersForAppointmentsResponseDto>> GetAppointmentRemindersForAppointmentsDetailsAsync(int appointmentsId, int appointmentRemindersId);
        Task<Response<List<GetAppointmentChargesForAppointmentsResponseDto>>> GetAppointmentChargesForAppointmentsAsync(int appointmentsId);
        Task<Response<GetAppointmentChargesForAppointmentsResponseDto>> GetAppointmentChargesForAppointmentsDetailsAsync(int appointmentsId, int appointmentChargesId);
        Task<Response<int>> ConfirmAsync(int appointmentId, ConfirmRequestDto updateRequest);
        Task<Response<int>> CancelAsync(int appointmentId, CancelRequestDto updateRequest);
    }
}