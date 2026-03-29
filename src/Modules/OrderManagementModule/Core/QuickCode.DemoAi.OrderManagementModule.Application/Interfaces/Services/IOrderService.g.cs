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
    public partial interface IOrderService
    {
        Task<Response<OrderDto>> InsertAsync(OrderDto request);
        Task<Response<bool>> DeleteAsync(OrderDto request);
        Task<Response<bool>> UpdateAsync(int id, OrderDto request);
        Task<Response<List<OrderDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<OrderDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByUserIdResponseDto>>> GetByUserIdAsync(int orderUserId, int? page, int? size);
        Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(OrderStatus orderStatus, int? page, int? size);
        Task<Response<List<GetPendingOrdersResponseDto>>> GetPendingOrdersAsync(OrderStatus orderStatus, int? page, int? size);
        Task<Response<List<GetOrdersByDateRangeResponseDto>>> GetOrdersByDateRangeAsync(DateTime orderOrderDateFrom, DateTime orderOrderDateTo, int? page, int? size);
        Task<Response<long>> GetHighValueOrdersAsync(decimal orderTotalAmount);
        Task<Response<int>> UpdateStatusAsync(int orderId, UpdateStatusRequestDto updateRequest);
        Task<Response<int>> CancelOrderAsync(int orderId, CancelOrderRequestDto updateRequest);
        Task<Response<int>> MarkAsShippedAsync(int orderId, MarkAsShippedRequestDto updateRequest);
    }
}