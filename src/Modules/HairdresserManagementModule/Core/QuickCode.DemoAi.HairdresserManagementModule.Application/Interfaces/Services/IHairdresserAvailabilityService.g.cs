using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.HairdresserAvailability;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Services.HairdresserAvailability
{
    public partial interface IHairdresserAvailabilityService
    {
        Task<Response<HairdresserAvailabilityDto>> InsertAsync(HairdresserAvailabilityDto request);
        Task<Response<bool>> DeleteAsync(HairdresserAvailabilityDto request);
        Task<Response<bool>> UpdateAsync(int id, HairdresserAvailabilityDto request);
        Task<Response<List<HairdresserAvailabilityDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<HairdresserAvailabilityDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByHairdresserIdResponseDto>>> GetByHairdresserIdAsync(int hairdresserAvailabilityHairdresserId, int? page, int? size);
    }
}