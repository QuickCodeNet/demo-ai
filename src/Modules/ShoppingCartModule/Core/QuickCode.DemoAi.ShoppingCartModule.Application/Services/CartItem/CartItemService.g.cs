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
    public partial class CartItemService : ICartItemService
    {
        private readonly ILogger<CartItemService> _logger;
        private readonly ICartItemRepository _repository;
        public CartItemService(ILogger<CartItemService> logger, ICartItemRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CartItemDto>> InsertAsync(CartItemDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CartItemDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CartItemDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CartItemDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CartItemDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCartIdResponseDto>>> GetByCartIdAsync(int cartItemCartId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCartIdAsync(cartItemCartId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> AdjustQuantityAsync(int cartItemId, AdjustQuantityRequestDto updateRequest)
        {
            var returnValue = await _repository.AdjustQuantityAsync(cartItemId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RemoveItemAsync(int cartItemId)
        {
            var returnValue = await _repository.RemoveItemAsync(cartItemId);
            return returnValue.ToResponse();
        }
    }
}