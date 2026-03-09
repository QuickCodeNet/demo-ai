using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.Common.Controllers;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.Appointment;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Services.Appointment;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Api.Controllers
{
    public partial class AppointmentsController : QuickCodeBaseApiController
    {
        private readonly IAppointmentService service;
        private readonly ILogger<AppointmentsController> logger;
        private readonly IServiceProvider serviceProvider;
        public AppointmentsController(IAppointmentService service, IServiceProvider serviceProvider, ILogger<AppointmentsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AppointmentDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Appointment", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Appointment") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppointmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Appointment", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AppointmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(AppointmentDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Appointment") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, AppointmentDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Appointment", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await service.DeleteItemAsync(id);
            if (HandleResponseError(response, logger, "Appointment", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer-id/{appointmentCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCustomerIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerIdAsync(int appointmentCustomerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCustomerIdAsync(appointmentCustomerId, page, size);
            if (HandleResponseError(response, logger, "Appointment", $"AppointmentCustomerId: '{appointmentCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-service-id/{appointmentServiceId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByServiceIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByServiceIdAsync(int appointmentServiceId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByServiceIdAsync(appointmentServiceId, page, size);
            if (HandleResponseError(response, logger, "Appointment", $"AppointmentServiceId: '{appointmentServiceId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-date-range")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByDateRangeResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByDateRangeAsync(DateTime appointmentAppointmentDateFrom, DateTime appointmentAppointmentDateTo, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByDateRangeAsync(appointmentAppointmentDateFrom, appointmentAppointmentDateTo, page, size);
            if (HandleResponseError(response, logger, "Appointment", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{appointmentId}/appointment-feedback")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAppointmentFeedbacksForAppointmentsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAppointmentFeedbacksForAppointmentsAsync(int appointmentsId)
        {
            var response = await service.GetAppointmentFeedbacksForAppointmentsAsync(appointmentsId);
            if (HandleResponseError(response, logger, "Appointment", $"AppointmentsId: '{appointmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{appointmentId}/appointment-feedback/{appointmentFeedbackId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAppointmentFeedbacksForAppointmentsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAppointmentFeedbacksForAppointmentsDetailsAsync(int appointmentsId, int appointmentFeedbacksId)
        {
            var response = await service.GetAppointmentFeedbacksForAppointmentsDetailsAsync(appointmentsId, appointmentFeedbacksId);
            if (HandleResponseError(response, logger, "Appointment", $"AppointmentsId: '{appointmentsId}', AppointmentFeedbacksId: '{appointmentFeedbacksId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{appointmentId}/appointment-reminder")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAppointmentRemindersForAppointmentsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAppointmentRemindersForAppointmentsAsync(int appointmentsId)
        {
            var response = await service.GetAppointmentRemindersForAppointmentsAsync(appointmentsId);
            if (HandleResponseError(response, logger, "Appointment", $"AppointmentsId: '{appointmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{appointmentId}/appointment-reminder/{appointmentReminderId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAppointmentRemindersForAppointmentsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAppointmentRemindersForAppointmentsDetailsAsync(int appointmentsId, int appointmentRemindersId)
        {
            var response = await service.GetAppointmentRemindersForAppointmentsDetailsAsync(appointmentsId, appointmentRemindersId);
            if (HandleResponseError(response, logger, "Appointment", $"AppointmentsId: '{appointmentsId}', AppointmentRemindersId: '{appointmentRemindersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{appointmentId}/appointment-charge")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAppointmentChargesForAppointmentsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAppointmentChargesForAppointmentsAsync(int appointmentsId)
        {
            var response = await service.GetAppointmentChargesForAppointmentsAsync(appointmentsId);
            if (HandleResponseError(response, logger, "Appointment", $"AppointmentsId: '{appointmentsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{appointmentId}/appointment-charge/{appointmentChargeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAppointmentChargesForAppointmentsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAppointmentChargesForAppointmentsDetailsAsync(int appointmentsId, int appointmentChargesId)
        {
            var response = await service.GetAppointmentChargesForAppointmentsDetailsAsync(appointmentsId, appointmentChargesId);
            if (HandleResponseError(response, logger, "Appointment", $"AppointmentsId: '{appointmentsId}', AppointmentChargesId: '{appointmentChargesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("confirm/{appointmentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ConfirmAsync(int appointmentId, [FromBody] ConfirmRequestDto updateRequest)
        {
            var response = await service.ConfirmAsync(appointmentId, updateRequest);
            if (HandleResponseError(response, logger, "Appointment", $"AppointmentId: '{appointmentId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("cancel/{appointmentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CancelAsync(int appointmentId, [FromBody] CancelRequestDto updateRequest)
        {
            var response = await service.CancelAsync(appointmentId, updateRequest);
            if (HandleResponseError(response, logger, "Appointment", $"AppointmentId: '{appointmentId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}