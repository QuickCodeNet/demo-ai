using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.Common.Controllers;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.Hairdresser;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Services.Hairdresser;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Api.Controllers
{
    public partial class HairdressersController : QuickCodeBaseApiController
    {
        private readonly IHairdresserService service;
        private readonly ILogger<HairdressersController> logger;
        private readonly IServiceProvider serviceProvider;
        public HairdressersController(IHairdresserService service, IServiceProvider serviceProvider, ILogger<HairdressersController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HairdresserDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Hairdresser", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Hairdresser") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HairdresserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Hairdresser", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HairdresserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(HairdresserDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Hairdresser") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, HairdresserDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Hairdresser", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Hairdresser", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active/{hairdresserIsActive:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetActiveResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveAsync(bool hairdresserIsActive, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetActiveAsync(hairdresserIsActive, page, size);
            if (HandleResponseError(response, logger, "Hairdresser", $"HairdresserIsActive: '{hairdresserIsActive}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("search-by-name/{hairdresserName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SearchByNameResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SearchByNameAsync(string hairdresserName, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.SearchByNameAsync(hairdresserName, page, size);
            if (HandleResponseError(response, logger, "Hairdresser", $"HairdresserName: '{hairdresserName}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{hairdresserId}/service")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetServicesForHairdressersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetServicesForHairdressersAsync(int hairdressersId)
        {
            var response = await service.GetServicesForHairdressersAsync(hairdressersId);
            if (HandleResponseError(response, logger, "Hairdresser", $"HairdressersId: '{hairdressersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{hairdresserId}/service/{serviceId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetServicesForHairdressersResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetServicesForHairdressersDetailsAsync(int hairdressersId, int servicesId)
        {
            var response = await service.GetServicesForHairdressersDetailsAsync(hairdressersId, servicesId);
            if (HandleResponseError(response, logger, "Hairdresser", $"HairdressersId: '{hairdressersId}', ServicesId: '{servicesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{hairdresserId}/hairdresser-availability")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetHairdresserAvailabilitiesForHairdressersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetHairdresserAvailabilitiesForHairdressersAsync(int hairdressersId)
        {
            var response = await service.GetHairdresserAvailabilitiesForHairdressersAsync(hairdressersId);
            if (HandleResponseError(response, logger, "Hairdresser", $"HairdressersId: '{hairdressersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{hairdresserId}/hairdresser-availability/{hairdresserAvailabilityId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetHairdresserAvailabilitiesForHairdressersResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetHairdresserAvailabilitiesForHairdressersDetailsAsync(int hairdressersId, int hairdresserAvailabilitiesId)
        {
            var response = await service.GetHairdresserAvailabilitiesForHairdressersDetailsAsync(hairdressersId, hairdresserAvailabilitiesId);
            if (HandleResponseError(response, logger, "Hairdresser", $"HairdressersId: '{hairdressersId}', HairdresserAvailabilitiesId: '{hairdresserAvailabilitiesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{hairdresserId}/hairdresser-note")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetHairdresserNotesForHairdressersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetHairdresserNotesForHairdressersAsync(int hairdressersId)
        {
            var response = await service.GetHairdresserNotesForHairdressersAsync(hairdressersId);
            if (HandleResponseError(response, logger, "Hairdresser", $"HairdressersId: '{hairdressersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{hairdresserId}/hairdresser-note/{hairdresserNoteId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetHairdresserNotesForHairdressersResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetHairdresserNotesForHairdressersDetailsAsync(int hairdressersId, int hairdresserNotesId)
        {
            var response = await service.GetHairdresserNotesForHairdressersDetailsAsync(hairdressersId, hairdresserNotesId);
            if (HandleResponseError(response, logger, "Hairdresser", $"HairdressersId: '{hairdressersId}', HairdresserNotesId: '{hairdresserNotesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("activate/{hairdresserId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ActivateAsync(int hairdresserId, [FromBody] ActivateRequestDto updateRequest)
        {
            var response = await service.ActivateAsync(hairdresserId, updateRequest);
            if (HandleResponseError(response, logger, "Hairdresser", $"HairdresserId: '{hairdresserId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("deactivate/{hairdresserId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeactivateAsync(int hairdresserId, [FromBody] DeactivateRequestDto updateRequest)
        {
            var response = await service.DeactivateAsync(hairdresserId, updateRequest);
            if (HandleResponseError(response, logger, "Hairdresser", $"HairdresserId: '{hairdresserId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}