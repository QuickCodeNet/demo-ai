using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.OrderModule.Domain.Entities;
using QuickCode.DemoAi.OrderModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.OrderModule.Application.Dtos.OrderItem;
using QuickCode.DemoAi.OrderModule.Domain.Enums;

namespace QuickCode.DemoAi.OrderModule.Application.Services.OrderItem
{
    public partial class OrderItemService : IOrderItemService
    {
        private readonly ILogger<OrderItemService> _logger;
        private readonly IOrderItemRepository _repository;
        public OrderItemService(ILogger<OrderItemService> logger, IOrderItemRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<OrderItemDto>> InsertAsync(OrderItemDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(OrderItemDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, OrderItemDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<OrderItemDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<OrderItemDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByOrderResponseDto>>> GetByOrderAsync(int orderItemOrderId, int? page, int? size)
        {
            var returnValue = await _repository.GetByOrderAsync(orderItemOrderId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int orderItemProductId, int? page, int? size)
        {
            var returnValue = await _repository.GetByProductAsync(orderItemProductId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<long>> GetTotalQuantityByProductAsync(int orderItemProductId)
        {
            var returnValue = await _repository.GetTotalQuantityByProductAsync(orderItemProductId);
            return returnValue.ToResponse();
        }
    }
}