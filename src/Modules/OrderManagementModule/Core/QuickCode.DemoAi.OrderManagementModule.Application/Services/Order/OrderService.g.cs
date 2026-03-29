using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.OrderManagementModule.Domain.Entities;
using QuickCode.DemoAi.OrderManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.OrderManagementModule.Application.Dtos.Order;
using QuickCode.DemoAi.OrderManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.OrderManagementModule.Application.Services.Order
{
    public partial class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepository _repository;
        public OrderService(ILogger<OrderService> logger, IOrderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<OrderDto>> InsertAsync(OrderDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(OrderDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, OrderDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<OrderDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<OrderDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByUserIdResponseDto>>> GetByUserIdAsync(int orderUserId, int? page, int? size)
        {
            var returnValue = await _repository.GetByUserIdAsync(orderUserId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(OrderStatus orderStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetByStatusAsync(orderStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetPendingOrdersResponseDto>>> GetPendingOrdersAsync(OrderStatus orderStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetPendingOrdersAsync(orderStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetOrdersByDateRangeResponseDto>>> GetOrdersByDateRangeAsync(DateTime orderOrderDateFrom, DateTime orderOrderDateTo, int? page, int? size)
        {
            var returnValue = await _repository.GetOrdersByDateRangeAsync(orderOrderDateFrom, orderOrderDateTo, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<long>> GetHighValueOrdersAsync(decimal orderTotalAmount)
        {
            var returnValue = await _repository.GetHighValueOrdersAsync(orderTotalAmount);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateStatusAsync(int orderId, UpdateStatusRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateStatusAsync(orderId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> CancelOrderAsync(int orderId, CancelOrderRequestDto updateRequest)
        {
            var returnValue = await _repository.CancelOrderAsync(orderId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> MarkAsShippedAsync(int orderId, MarkAsShippedRequestDto updateRequest)
        {
            var returnValue = await _repository.MarkAsShippedAsync(orderId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}