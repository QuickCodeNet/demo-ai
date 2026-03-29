using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.ProductCatalogModule.Domain.Entities;
using QuickCode.DemoAi.ProductCatalogModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.ProductCatalogModule.Application.Dtos.ProductCategory;
using QuickCode.DemoAi.ProductCatalogModule.Domain.Enums;

namespace QuickCode.DemoAi.ProductCatalogModule.Application.Services.ProductCategory
{
    public partial interface IProductCategoryService
    {
        Task<Response<ProductCategoryDto>> InsertAsync(ProductCategoryDto request);
        Task<Response<bool>> DeleteAsync(ProductCategoryDto request);
        Task<Response<bool>> UpdateAsync(int productId, int categoryId, ProductCategoryDto request);
        Task<Response<List<ProductCategoryDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ProductCategoryDto>> GetItemAsync(int productId, int categoryId);
        Task<Response<bool>> DeleteItemAsync(int productId, int categoryId);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByProductIdResponseDto>>> GetByProductIdAsync(int productCategoryProductId, int? page, int? size);
        Task<Response<List<GetByCategoryIdResponseDto>>> GetByCategoryIdAsync(int productCategoryCategoryId, int? page, int? size);
        Task<Response<int>> RemoveCategoryAsync(int productCategoryProductId, int productCategoryCategoryId);
    }
}