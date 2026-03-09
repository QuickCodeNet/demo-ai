using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.Service;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Services.Service
{
    public partial interface IServiceService
    {
        Task<Response<ServiceDto>> InsertAsync(ServiceDto request);
        Task<Response<bool>> DeleteAsync(ServiceDto request);
        Task<Response<bool>> UpdateAsync(int id, ServiceDto request);
        Task<Response<List<ServiceDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ServiceDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByHairdresserIdResponseDto>>> GetByHairdresserIdAsync(int serviceHairdresserId, int? page, int? size);
        Task<Response<List<GetByCategoryResponseDto>>> GetByCategoryAsync(ServiceCategory serviceCategory, int? page, int? size);
        Task<Response<List<GetServicePricesForServicesResponseDto>>> GetServicePricesForServicesAsync(int servicesId);
        Task<Response<GetServicePricesForServicesResponseDto>> GetServicePricesForServicesDetailsAsync(int servicesId, int servicePricesId);
        Task<Response<int>> UpdatePriceAsync(int serviceId, UpdatePriceRequestDto updateRequest);
    }
}