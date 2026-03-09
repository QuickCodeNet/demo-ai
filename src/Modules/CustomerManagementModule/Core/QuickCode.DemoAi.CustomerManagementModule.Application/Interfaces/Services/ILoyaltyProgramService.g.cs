using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoAi.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.LoyaltyProgram;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Application.Services.LoyaltyProgram
{
    public partial interface ILoyaltyProgramService
    {
        Task<Response<LoyaltyProgramDto>> InsertAsync(LoyaltyProgramDto request);
        Task<Response<bool>> DeleteAsync(LoyaltyProgramDto request);
        Task<Response<bool>> UpdateAsync(int id, LoyaltyProgramDto request);
        Task<Response<List<LoyaltyProgramDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<LoyaltyProgramDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetAllResponseDto>>> GetAllAsync();
        Task<Response<List<GetCustomerLoyaltyPointsForLoyaltyProgramsResponseDto>>> GetCustomerLoyaltyPointsForLoyaltyProgramsAsync(int loyaltyProgramsId);
        Task<Response<GetCustomerLoyaltyPointsForLoyaltyProgramsResponseDto>> GetCustomerLoyaltyPointsForLoyaltyProgramsDetailsAsync(int loyaltyProgramsId, int customerLoyaltyPointsId);
    }
}