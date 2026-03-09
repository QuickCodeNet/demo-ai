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
    public partial class AppointmentService : IAppointmentService
    {
        private readonly ILogger<AppointmentService> _logger;
        private readonly IAppointmentRepository _repository;
        public AppointmentService(ILogger<AppointmentService> logger, IAppointmentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AppointmentDto>> InsertAsync(AppointmentDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AppointmentDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AppointmentDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AppointmentDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AppointmentDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int appointmentCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerIdAsync(appointmentCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByServiceIdResponseDto>>> GetByServiceIdAsync(int appointmentServiceId, int? page, int? size)
        {
            var returnValue = await _repository.GetByServiceIdAsync(appointmentServiceId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByDateRangeResponseDto>>> GetByDateRangeAsync(DateTime appointmentAppointmentDateFrom, DateTime appointmentAppointmentDateTo, int? page, int? size)
        {
            var returnValue = await _repository.GetByDateRangeAsync(appointmentAppointmentDateFrom, appointmentAppointmentDateTo, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetAppointmentFeedbacksForAppointmentsResponseDto>>> GetAppointmentFeedbacksForAppointmentsAsync(int appointmentsId)
        {
            var returnValue = await _repository.GetAppointmentFeedbacksForAppointmentsAsync(appointmentsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetAppointmentFeedbacksForAppointmentsResponseDto>> GetAppointmentFeedbacksForAppointmentsDetailsAsync(int appointmentsId, int appointmentFeedbacksId)
        {
            var returnValue = await _repository.GetAppointmentFeedbacksForAppointmentsDetailsAsync(appointmentsId, appointmentFeedbacksId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetAppointmentRemindersForAppointmentsResponseDto>>> GetAppointmentRemindersForAppointmentsAsync(int appointmentsId)
        {
            var returnValue = await _repository.GetAppointmentRemindersForAppointmentsAsync(appointmentsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetAppointmentRemindersForAppointmentsResponseDto>> GetAppointmentRemindersForAppointmentsDetailsAsync(int appointmentsId, int appointmentRemindersId)
        {
            var returnValue = await _repository.GetAppointmentRemindersForAppointmentsDetailsAsync(appointmentsId, appointmentRemindersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetAppointmentChargesForAppointmentsResponseDto>>> GetAppointmentChargesForAppointmentsAsync(int appointmentsId)
        {
            var returnValue = await _repository.GetAppointmentChargesForAppointmentsAsync(appointmentsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetAppointmentChargesForAppointmentsResponseDto>> GetAppointmentChargesForAppointmentsDetailsAsync(int appointmentsId, int appointmentChargesId)
        {
            var returnValue = await _repository.GetAppointmentChargesForAppointmentsDetailsAsync(appointmentsId, appointmentChargesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ConfirmAsync(int appointmentId, ConfirmRequestDto updateRequest)
        {
            var returnValue = await _repository.ConfirmAsync(appointmentId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> CancelAsync(int appointmentId, CancelRequestDto updateRequest)
        {
            var returnValue = await _repository.CancelAsync(appointmentId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}