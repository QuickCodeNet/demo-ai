using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.Common.Controllers;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.AppointmentReminder;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Services.AppointmentReminder;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Api.Controllers
{
    public partial class AppointmentRemindersController : QuickCodeBaseApiController
    {
        private readonly IAppointmentReminderService service;
        private readonly ILogger<AppointmentRemindersController> logger;
        private readonly IServiceProvider serviceProvider;
        public AppointmentRemindersController(IAppointmentReminderService service, IServiceProvider serviceProvider, ILogger<AppointmentRemindersController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AppointmentReminderDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "AppointmentReminder", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "AppointmentReminder") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppointmentReminderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "AppointmentReminder", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AppointmentReminderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(AppointmentReminderDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "AppointmentReminder") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, AppointmentReminderDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "AppointmentReminder", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "AppointmentReminder", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-unsent-reminders/{appointmentReminderIsSent:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetUnsentRemindersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetUnsentRemindersAsync(bool appointmentReminderIsSent)
        {
            var response = await service.GetUnsentRemindersAsync(appointmentReminderIsSent);
            if (HandleResponseError(response, logger, "AppointmentReminder", $"AppointmentReminderIsSent: '{appointmentReminderIsSent}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("mark-sent/{appointmentReminderId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> MarkSentAsync(int appointmentReminderId, [FromBody] MarkSentRequestDto updateRequest)
        {
            var response = await service.MarkSentAsync(appointmentReminderId, updateRequest);
            if (HandleResponseError(response, logger, "AppointmentReminder", $"AppointmentReminderId: '{appointmentReminderId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}