using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.HairdresserAvailability;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Services.HairdresserAvailability
{
    public partial class HairdresserAvailabilityService : IHairdresserAvailabilityService
    {
        private readonly ILogger<HairdresserAvailabilityService> _logger;
        private readonly IHairdresserAvailabilityRepository _repository;
        public HairdresserAvailabilityService(ILogger<HairdresserAvailabilityService> logger, IHairdresserAvailabilityRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<HairdresserAvailabilityDto>> InsertAsync(HairdresserAvailabilityDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(HairdresserAvailabilityDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, HairdresserAvailabilityDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<HairdresserAvailabilityDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<HairdresserAvailabilityDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByHairdresserIdResponseDto>>> GetByHairdresserIdAsync(int hairdresserAvailabilityHairdresserId, int? page, int? size)
        {
            var returnValue = await _repository.GetByHairdresserIdAsync(hairdresserAvailabilityHairdresserId, page, size);
            return returnValue.ToResponse();
        }
    }
}