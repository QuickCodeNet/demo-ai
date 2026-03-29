using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.ProductCatalogModule.Domain.Entities;
using QuickCode.DemoAi.ProductCatalogModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.ProductCatalogModule.Application.Dtos.Product;
using QuickCode.DemoAi.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoAi.ProductCatalogModule.Application.Services.Product
{
    public partial class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _repository;
        public ProductService(ILogger<ProductService> logger, IProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ProductDto>> InsertAsync(ProductDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ProductDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ProductDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ProductDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ProductDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(ProductStatus productStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(productStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string productName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(productName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByCategoryIdResponseDto>>> GetByCategoryIdAsync(int productCategoriesCategoryId, int productsId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCategoryIdAsync(productCategoriesCategoryId, productsId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<long>> GetLowStockAsync(int productStockQuantity)
        {
            var returnValue = await _repository.GetLowStockAsync(productStockQuantity);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> AdjustStockAsync(int productId, AdjustStockRequestDto updateRequest)
        {
            var returnValue = await _repository.AdjustStockAsync(productId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> SetPriceAsync(int productId, SetPriceRequestDto updateRequest)
        {
            var returnValue = await _repository.SetPriceAsync(productId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ActivateAsync(int productId, ActivateRequestDto updateRequest)
        {
            var returnValue = await _repository.ActivateAsync(productId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int productId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(productId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}