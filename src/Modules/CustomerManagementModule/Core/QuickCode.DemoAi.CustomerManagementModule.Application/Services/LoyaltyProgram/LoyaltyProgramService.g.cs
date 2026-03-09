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
    public partial class LoyaltyProgramService : ILoyaltyProgramService
    {
        private readonly ILogger<LoyaltyProgramService> _logger;
        private readonly ILoyaltyProgramRepository _repository;
        public LoyaltyProgramService(ILogger<LoyaltyProgramService> logger, ILoyaltyProgramRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<LoyaltyProgramDto>> InsertAsync(LoyaltyProgramDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(LoyaltyProgramDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, LoyaltyProgramDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<LoyaltyProgramDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<LoyaltyProgramDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetAllResponseDto>>> GetAllAsync()
        {
            var returnValue = await _repository.GetAllAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetCustomerLoyaltyPointsForLoyaltyProgramsResponseDto>>> GetCustomerLoyaltyPointsForLoyaltyProgramsAsync(int loyaltyProgramsId)
        {
            var returnValue = await _repository.GetCustomerLoyaltyPointsForLoyaltyProgramsAsync(loyaltyProgramsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetCustomerLoyaltyPointsForLoyaltyProgramsResponseDto>> GetCustomerLoyaltyPointsForLoyaltyProgramsDetailsAsync(int loyaltyProgramsId, int customerLoyaltyPointsId)
        {
            var returnValue = await _repository.GetCustomerLoyaltyPointsForLoyaltyProgramsDetailsAsync(loyaltyProgramsId, customerLoyaltyPointsId);
            return returnValue.ToResponse();
        }
    }
}