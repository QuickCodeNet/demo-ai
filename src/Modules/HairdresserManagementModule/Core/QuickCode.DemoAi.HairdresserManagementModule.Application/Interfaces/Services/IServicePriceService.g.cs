using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.ServicePrice;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Services.ServicePrice
{
    public partial interface IServicePriceService
    {
        Task<Response<ServicePriceDto>> InsertAsync(ServicePriceDto request);
        Task<Response<bool>> DeleteAsync(ServicePriceDto request);
        Task<Response<bool>> UpdateAsync(int id, ServicePriceDto request);
        Task<Response<List<ServicePriceDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ServicePriceDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByServiceIdResponseDto>>> GetByServiceIdAsync(int servicePriceServiceId, int? page, int? size);
    }
}