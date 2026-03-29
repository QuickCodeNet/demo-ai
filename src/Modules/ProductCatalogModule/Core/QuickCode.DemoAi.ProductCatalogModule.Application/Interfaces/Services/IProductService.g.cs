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
    public partial interface IProductService
    {
        Task<Response<ProductDto>> InsertAsync(ProductDto request);
        Task<Response<bool>> DeleteAsync(ProductDto request);
        Task<Response<bool>> UpdateAsync(int id, ProductDto request);
        Task<Response<List<ProductDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ProductDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(ProductStatus productStatus, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string productName, int? page, int? size);
        Task<Response<List<GetByCategoryIdResponseDto>>> GetByCategoryIdAsync(int productCategoriesCategoryId, int productsId, int? page, int? size);
        Task<Response<long>> GetLowStockAsync(int productStockQuantity);
        Task<Response<int>> AdjustStockAsync(int productId, AdjustStockRequestDto updateRequest);
        Task<Response<int>> SetPriceAsync(int productId, SetPriceRequestDto updateRequest);
        Task<Response<int>> ActivateAsync(int productId, ActivateRequestDto updateRequest);
        Task<Response<int>> DeactivateAsync(int productId, DeactivateRequestDto updateRequest);
    }
}