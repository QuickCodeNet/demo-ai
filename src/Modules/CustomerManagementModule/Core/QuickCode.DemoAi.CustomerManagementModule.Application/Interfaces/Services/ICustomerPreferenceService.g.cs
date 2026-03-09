using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoAi.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.CustomerPreference;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Application.Services.CustomerPreference
{
    public partial interface ICustomerPreferenceService
    {
        Task<Response<CustomerPreferenceDto>> InsertAsync(CustomerPreferenceDto request);
        Task<Response<bool>> DeleteAsync(CustomerPreferenceDto request);
        Task<Response<bool>> UpdateAsync(int id, CustomerPreferenceDto request);
        Task<Response<List<CustomerPreferenceDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CustomerPreferenceDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int customerPreferenceCustomerId, int? page, int? size);
    }
}