using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.ShoppingCartModule.Domain.Entities;
using QuickCode.DemoAi.ShoppingCartModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.ShoppingCartModule.Application.Dtos.CartItem;

namespace QuickCode.DemoAi.ShoppingCartModule.Application.Services.CartItem
{
    public partial interface ICartItemService
    {
        Task<Response<CartItemDto>> InsertAsync(CartItemDto request);
        Task<Response<bool>> DeleteAsync(CartItemDto request);
        Task<Response<bool>> UpdateAsync(int id, CartItemDto request);
        Task<Response<List<CartItemDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CartItemDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCartIdResponseDto>>> GetByCartIdAsync(int cartItemCartId, int? page, int? size);
        Task<Response<int>> AdjustQuantityAsync(int cartItemId, AdjustQuantityRequestDto updateRequest);
        Task<Response<int>> RemoveItemAsync(int cartItemId);
    }
}