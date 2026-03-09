using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.SalonEquipment;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Services.SalonEquipment
{
    public partial interface ISalonEquipmentService
    {
        Task<Response<SalonEquipmentDto>> InsertAsync(SalonEquipmentDto request);
        Task<Response<bool>> DeleteAsync(SalonEquipmentDto request);
        Task<Response<bool>> UpdateAsync(int id, SalonEquipmentDto request);
        Task<Response<List<SalonEquipmentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<SalonEquipmentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetAllResponseDto>>> GetAllAsync();
        Task<Response<int>> UpdateQuantityAsync(int salonEquipmentId, UpdateQuantityRequestDto updateRequest);
    }
}