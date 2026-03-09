using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoAi.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.CustomerLoyaltyPoint;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Application.Services.CustomerLoyaltyPoint
{
    public partial interface ICustomerLoyaltyPointService
    {
        Task<Response<CustomerLoyaltyPointDto>> InsertAsync(CustomerLoyaltyPointDto request);
        Task<Response<bool>> DeleteAsync(CustomerLoyaltyPointDto request);
        Task<Response<bool>> UpdateAsync(int id, CustomerLoyaltyPointDto request);
        Task<Response<List<CustomerLoyaltyPointDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CustomerLoyaltyPointDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int customerLoyaltyPointCustomerId, int? page, int? size);
    }
}