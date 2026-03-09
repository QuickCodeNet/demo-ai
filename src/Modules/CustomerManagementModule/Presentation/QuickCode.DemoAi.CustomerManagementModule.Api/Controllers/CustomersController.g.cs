using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoAi.Common.Controllers;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.Customer;
using QuickCode.DemoAi.CustomerManagementModule.Application.Services.Customer;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Api.Controllers
{
    public partial class CustomersController : QuickCodeBaseApiController
    {
        private readonly ICustomerService service;
        private readonly ILogger<CustomersController> logger;
        private readonly IServiceProvider serviceProvider;
        public CustomersController(ICustomerService service, IServiceProvider serviceProvider, ILogger<CustomersController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Customer", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Customer") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Customer", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(CustomerDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Customer") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, CustomerDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Customer", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Customer", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active/{customerIsActive:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetActiveResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveAsync(bool customerIsActive, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetActiveAsync(customerIsActive, page, size);
            if (HandleResponseError(response, logger, "Customer", $"CustomerIsActive: '{customerIsActive}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("search-by-name/{customerFirstName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SearchByNameResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SearchByNameAsync(string customerFirstName, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.SearchByNameAsync(customerFirstName, page, size);
            if (HandleResponseError(response, logger, "Customer", $"CustomerFirstName: '{customerFirstName}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{customerId}/customer-address")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetCustomerAddressesForCustomersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerAddressesForCustomersAsync(int customersId)
        {
            var response = await service.GetCustomerAddressesForCustomersAsync(customersId);
            if (HandleResponseError(response, logger, "Customer", $"CustomersId: '{customersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{customerId}/customer-address/{customerAddressId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCustomerAddressesForCustomersResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerAddressesForCustomersDetailsAsync(int customersId, int customerAddressesId)
        {
            var response = await service.GetCustomerAddressesForCustomersDetailsAsync(customersId, customerAddressesId);
            if (HandleResponseError(response, logger, "Customer", $"CustomersId: '{customersId}', CustomerAddressesId: '{customerAddressesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{customerId}/customer-note")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetCustomerNotesForCustomersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerNotesForCustomersAsync(int customersId)
        {
            var response = await service.GetCustomerNotesForCustomersAsync(customersId);
            if (HandleResponseError(response, logger, "Customer", $"CustomersId: '{customersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{customerId}/customer-note/{customerNoteId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCustomerNotesForCustomersResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerNotesForCustomersDetailsAsync(int customersId, int customerNotesId)
        {
            var response = await service.GetCustomerNotesForCustomersDetailsAsync(customersId, customerNotesId);
            if (HandleResponseError(response, logger, "Customer", $"CustomersId: '{customersId}', CustomerNotesId: '{customerNotesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{customerId}/customer-preference")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetCustomerPreferencesForCustomersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerPreferencesForCustomersAsync(int customersId)
        {
            var response = await service.GetCustomerPreferencesForCustomersAsync(customersId);
            if (HandleResponseError(response, logger, "Customer", $"CustomersId: '{customersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{customerId}/customer-preference/{customerPreferenceId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCustomerPreferencesForCustomersResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerPreferencesForCustomersDetailsAsync(int customersId, int customerPreferencesId)
        {
            var response = await service.GetCustomerPreferencesForCustomersDetailsAsync(customersId, customerPreferencesId);
            if (HandleResponseError(response, logger, "Customer", $"CustomersId: '{customersId}', CustomerPreferencesId: '{customerPreferencesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{customerId}/customer-loyalty-point")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetCustomerLoyaltyPointsForCustomersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerLoyaltyPointsForCustomersAsync(int customersId)
        {
            var response = await service.GetCustomerLoyaltyPointsForCustomersAsync(customersId);
            if (HandleResponseError(response, logger, "Customer", $"CustomersId: '{customersId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{customerId}/customer-loyalty-point/{customerLoyaltyPointId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCustomerLoyaltyPointsForCustomersResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerLoyaltyPointsForCustomersDetailsAsync(int customersId, int customerLoyaltyPointsId)
        {
            var response = await service.GetCustomerLoyaltyPointsForCustomersDetailsAsync(customersId, customerLoyaltyPointsId);
            if (HandleResponseError(response, logger, "Customer", $"CustomersId: '{customersId}', CustomerLoyaltyPointsId: '{customerLoyaltyPointsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("activate/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ActivateAsync(int customerId, [FromBody] ActivateRequestDto updateRequest)
        {
            var response = await service.ActivateAsync(customerId, updateRequest);
            if (HandleResponseError(response, logger, "Customer", $"CustomerId: '{customerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("deactivate/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeactivateAsync(int customerId, [FromBody] DeactivateRequestDto updateRequest)
        {
            var response = await service.DeactivateAsync(customerId, updateRequest);
            if (HandleResponseError(response, logger, "Customer", $"CustomerId: '{customerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}