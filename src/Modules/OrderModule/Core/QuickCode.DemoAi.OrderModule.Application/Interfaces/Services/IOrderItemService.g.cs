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
    public partial interface IOrderItemService
    {
        Task<Response<OrderItemDto>> InsertAsync(OrderItemDto request);
        Task<Response<bool>> DeleteAsync(OrderItemDto request);
        Task<Response<bool>> UpdateAsync(int id, OrderItemDto request);
        Task<Response<List<OrderItemDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<OrderItemDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByOrderResponseDto>>> GetByOrderAsync(int orderItemOrderId, int? page, int? size);
        Task<Response<List<GetByProductResponseDto>>> GetByProductAsync(int orderItemProductId, int? page, int? size);
        Task<Response<long>> GetTotalQuantityByProductAsync(int orderItemProductId);
    }
}