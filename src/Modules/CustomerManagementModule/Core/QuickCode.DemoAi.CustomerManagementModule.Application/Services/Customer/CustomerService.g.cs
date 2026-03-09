using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoAi.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.Customer;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Application.Services.Customer
{
    public partial class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepository _repository;
        public CustomerService(ILogger<CustomerService> logger, ICustomerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CustomerDto>> InsertAsync(CustomerDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CustomerDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CustomerDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CustomerDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CustomerDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool customerIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(customerIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string customerFirstName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(customerFirstName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetCustomerAddressesForCustomersResponseDto>>> GetCustomerAddressesForCustomersAsync(int customersId)
        {
            var returnValue = await _repository.GetCustomerAddressesForCustomersAsync(customersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetCustomerAddressesForCustomersResponseDto>> GetCustomerAddressesForCustomersDetailsAsync(int customersId, int customerAddressesId)
        {
            var returnValue = await _repository.GetCustomerAddressesForCustomersDetailsAsync(customersId, customerAddressesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetCustomerNotesForCustomersResponseDto>>> GetCustomerNotesForCustomersAsync(int customersId)
        {
            var returnValue = await _repository.GetCustomerNotesForCustomersAsync(customersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetCustomerNotesForCustomersResponseDto>> GetCustomerNotesForCustomersDetailsAsync(int customersId, int customerNotesId)
        {
            var returnValue = await _repository.GetCustomerNotesForCustomersDetailsAsync(customersId, customerNotesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetCustomerPreferencesForCustomersResponseDto>>> GetCustomerPreferencesForCustomersAsync(int customersId)
        {
            var returnValue = await _repository.GetCustomerPreferencesForCustomersAsync(customersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetCustomerPreferencesForCustomersResponseDto>> GetCustomerPreferencesForCustomersDetailsAsync(int customersId, int customerPreferencesId)
        {
            var returnValue = await _repository.GetCustomerPreferencesForCustomersDetailsAsync(customersId, customerPreferencesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetCustomerLoyaltyPointsForCustomersResponseDto>>> GetCustomerLoyaltyPointsForCustomersAsync(int customersId)
        {
            var returnValue = await _repository.GetCustomerLoyaltyPointsForCustomersAsync(customersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetCustomerLoyaltyPointsForCustomersResponseDto>> GetCustomerLoyaltyPointsForCustomersDetailsAsync(int customersId, int customerLoyaltyPointsId)
        {
            var returnValue = await _repository.GetCustomerLoyaltyPointsForCustomersDetailsAsync(customersId, customerLoyaltyPointsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ActivateAsync(int customerId, ActivateRequestDto updateRequest)
        {
            var returnValue = await _repository.ActivateAsync(customerId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int customerId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(customerId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}