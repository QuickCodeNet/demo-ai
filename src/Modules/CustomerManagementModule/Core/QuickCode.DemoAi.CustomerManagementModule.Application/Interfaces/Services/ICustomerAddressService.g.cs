using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoAi.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.CustomerAddress;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Application.Services.CustomerAddress
{
    public partial interface ICustomerAddressService
    {
        Task<Response<CustomerAddressDto>> InsertAsync(CustomerAddressDto request);
        Task<Response<bool>> DeleteAsync(CustomerAddressDto request);
        Task<Response<bool>> UpdateAsync(int id, CustomerAddressDto request);
        Task<Response<List<CustomerAddressDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CustomerAddressDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int customerAddressCustomerId, int? page, int? size);
        Task<Response<GetDefaultByCustomerResponseDto>> GetDefaultByCustomerAsync(int customerAddressCustomerId, bool? customerAddressIsDefault);
        Task<Response<int>> SetDefaultAsync(int customerAddressId, SetDefaultRequestDto updateRequest);
    }
}