using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.Common.Controllers;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.LoyaltyProgram;
using QuickCode.DemoAi.CustomerManagementModule.Application.Services.LoyaltyProgram;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Api.Controllers
{
    public partial class LoyaltyProgramsController : QuickCodeBaseApiController
    {
        private readonly ILoyaltyProgramService service;
        private readonly ILogger<LoyaltyProgramsController> logger;
        private readonly IServiceProvider serviceProvider;
        public LoyaltyProgramsController(ILoyaltyProgramService service, IServiceProvider serviceProvider, ILogger<LoyaltyProgramsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LoyaltyProgramDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "LoyaltyProgram", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "LoyaltyProgram") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoyaltyProgramDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "LoyaltyProgram", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LoyaltyProgramDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(LoyaltyProgramDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "LoyaltyProgram") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, LoyaltyProgramDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "LoyaltyProgram", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "LoyaltyProgram", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAllResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await service.GetAllAsync();
            if (HandleResponseError(response, logger, "LoyaltyProgram", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{loyaltyProgramId}/customer-loyalty-point")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetCustomerLoyaltyPointsForLoyaltyProgramsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerLoyaltyPointsForLoyaltyProgramsAsync(int loyaltyProgramsId)
        {
            var response = await service.GetCustomerLoyaltyPointsForLoyaltyProgramsAsync(loyaltyProgramsId);
            if (HandleResponseError(response, logger, "LoyaltyProgram", $"LoyaltyProgramsId: '{loyaltyProgramsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{loyaltyProgramId}/customer-loyalty-point/{customerLoyaltyPointId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCustomerLoyaltyPointsForLoyaltyProgramsResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerLoyaltyPointsForLoyaltyProgramsDetailsAsync(int loyaltyProgramsId, int customerLoyaltyPointsId)
        {
            var response = await service.GetCustomerLoyaltyPointsForLoyaltyProgramsDetailsAsync(loyaltyProgramsId, customerLoyaltyPointsId);
            if (HandleResponseError(response, logger, "LoyaltyProgram", $"LoyaltyProgramsId: '{loyaltyProgramsId}', CustomerLoyaltyPointsId: '{customerLoyaltyPointsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}