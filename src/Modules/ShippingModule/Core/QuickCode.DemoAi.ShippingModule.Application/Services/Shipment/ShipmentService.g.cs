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
    public partial class ShipmentService : IShipmentService
    {
        private readonly ILogger<ShipmentService> _logger;
        private readonly IShipmentRepository _repository;
        public ShipmentService(ILogger<ShipmentService> logger, IShipmentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ShipmentDto>> InsertAsync(ShipmentDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ShipmentDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ShipmentDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ShipmentDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ShipmentDto>> GetItemAsync(int id)
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

        public async Task<Response<GetByOrderIdResponseDto>> GetByOrderIdAsync(int shipmentOrderId)
        {
            var returnValue = await _repository.GetByOrderIdAsync(shipmentOrderId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ShippingStatus shipmentStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetByStatusAsync(shipmentStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateStatusAsync(int shipmentId, UpdateStatusRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateStatusAsync(shipmentId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}