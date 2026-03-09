using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.Common.Controllers;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.Service;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Services.Service;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Api.Controllers
{
    public partial class ServicesController : QuickCodeBaseApiController
    {
        private readonly IServiceService service;
        private readonly ILogger<ServicesController> logger;
        private readonly IServiceProvider serviceProvider;
        public ServicesController(IServiceService service, IServiceProvider serviceProvider, ILogger<ServicesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ServiceDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Service", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Service") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Service", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ServiceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(ServiceDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Service") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, ServiceDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Service", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Service", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-hairdresser-id/{serviceHairdresserId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByHairdresserIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByHairdresserIdAsync(int serviceHairdresserId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByHairdresserIdAsync(serviceHairdresserId, page, size);
            if (HandleResponseError(response, logger, "Service", $"ServiceHairdresserId: '{serviceHairdresserId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-category/{serviceCategory}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCategoryResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCategoryAsync(ServiceCategory serviceCategory, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCategoryAsync(serviceCategory, page, size);
            if (HandleResponseError(response, logger, "Service", $"ServiceCategory: '{serviceCategory}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{serviceId}/service-price")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetServicePricesForServicesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetServicePricesForServicesAsync(int servicesId)
        {
            var response = await service.GetServicePricesForServicesAsync(servicesId);
            if (HandleResponseError(response, logger, "Service", $"ServicesId: '{servicesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{serviceId}/service-price/{servicePriceId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetServicePricesForServicesResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetServicePricesForServicesDetailsAsync(int servicesId, int servicePricesId)
        {
            var response = await service.GetServicePricesForServicesDetailsAsync(servicesId, servicePricesId);
            if (HandleResponseError(response, logger, "Service", $"ServicesId: '{servicesId}', ServicePricesId: '{servicePricesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-price/{serviceId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdatePriceAsync(int serviceId, [FromBody] UpdatePriceRequestDto updateRequest)
        {
            var response = await service.UpdatePriceAsync(serviceId, updateRequest);
            if (HandleResponseError(response, logger, "Service", $"ServiceId: '{serviceId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}