using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.ShippingModule.Domain.Entities;
using QuickCode.DemoAi.ShippingModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.ShippingModule.Application.Dtos.Shipment;
using QuickCode.DemoAi.ShippingModule.Domain.Enums;

namespace QuickCode.DemoAi.ShippingModule.Application.Services.Shipment
{
    public partial interface IShipmentService
    {
        Task<Response<ShipmentDto>> InsertAsync(ShipmentDto request);
        Task<Response<bool>> DeleteAsync(ShipmentDto request);
        Task<Response<bool>> UpdateAsync(int id, ShipmentDto request);
        Task<Response<List<ShipmentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ShipmentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<GetByOrderIdResponseDto>> GetByOrderIdAsync(int shipmentOrderId);
        Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ShippingStatus shipmentStatus, int? page, int? size);
        Task<Response<int>> UpdateStatusAsync(int shipmentId, UpdateStatusRequestDto updateRequest);
    }
}