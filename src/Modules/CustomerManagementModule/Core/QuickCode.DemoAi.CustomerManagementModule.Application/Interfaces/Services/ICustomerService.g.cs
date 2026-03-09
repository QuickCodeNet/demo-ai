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
    public partial interface ICustomerService
    {
        Task<Response<CustomerDto>> InsertAsync(CustomerDto request);
        Task<Response<bool>> DeleteAsync(CustomerDto request);
        Task<Response<bool>> UpdateAsync(int id, CustomerDto request);
        Task<Response<List<CustomerDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CustomerDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool customerIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string customerFirstName, int? page, int? size);
        Task<Response<List<GetCustomerAddressesForCustomersResponseDto>>> GetCustomerAddressesForCustomersAsync(int customersId);
        Task<Response<GetCustomerAddressesForCustomersResponseDto>> GetCustomerAddressesForCustomersDetailsAsync(int customersId, int customerAddressesId);
        Task<Response<List<GetCustomerNotesForCustomersResponseDto>>> GetCustomerNotesForCustomersAsync(int customersId);
        Task<Response<GetCustomerNotesForCustomersResponseDto>> GetCustomerNotesForCustomersDetailsAsync(int customersId, int customerNotesId);
        Task<Response<List<GetCustomerPreferencesForCustomersResponseDto>>> GetCustomerPreferencesForCustomersAsync(int customersId);
        Task<Response<GetCustomerPreferencesForCustomersResponseDto>> GetCustomerPreferencesForCustomersDetailsAsync(int customersId, int customerPreferencesId);
        Task<Response<List<GetCustomerLoyaltyPointsForCustomersResponseDto>>> GetCustomerLoyaltyPointsForCustomersAsync(int customersId);
        Task<Response<GetCustomerLoyaltyPointsForCustomersResponseDto>> GetCustomerLoyaltyPointsForCustomersDetailsAsync(int customersId, int customerLoyaltyPointsId);
        Task<Response<int>> ActivateAsync(int customerId, ActivateRequestDto updateRequest);
        Task<Response<int>> DeactivateAsync(int customerId, DeactivateRequestDto updateRequest);
    }
}