using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.Hairdresser;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Services.Hairdresser
{
    public partial class HairdresserService : IHairdresserService
    {
        private readonly ILogger<HairdresserService> _logger;
        private readonly IHairdresserRepository _repository;
        public HairdresserService(ILogger<HairdresserService> logger, IHairdresserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<HairdresserDto>> InsertAsync(HairdresserDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(HairdresserDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, HairdresserDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<HairdresserDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<HairdresserDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool hairdresserIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(hairdresserIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string hairdresserName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(hairdresserName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetServicesForHairdressersResponseDto>>> GetServicesForHairdressersAsync(int hairdressersId)
        {
            var returnValue = await _repository.GetServicesForHairdressersAsync(hairdressersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetServicesForHairdressersResponseDto>> GetServicesForHairdressersDetailsAsync(int hairdressersId, int servicesId)
        {
            var returnValue = await _repository.GetServicesForHairdressersDetailsAsync(hairdressersId, servicesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetHairdresserAvailabilitiesForHairdressersResponseDto>>> GetHairdresserAvailabilitiesForHairdressersAsync(int hairdressersId)
        {
            var returnValue = await _repository.GetHairdresserAvailabilitiesForHairdressersAsync(hairdressersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetHairdresserAvailabilitiesForHairdressersResponseDto>> GetHairdresserAvailabilitiesForHairdressersDetailsAsync(int hairdressersId, int hairdresserAvailabilitiesId)
        {
            var returnValue = await _repository.GetHairdresserAvailabilitiesForHairdressersDetailsAsync(hairdressersId, hairdresserAvailabilitiesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetHairdresserNotesForHairdressersResponseDto>>> GetHairdresserNotesForHairdressersAsync(int hairdressersId)
        {
            var returnValue = await _repository.GetHairdresserNotesForHairdressersAsync(hairdressersId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetHairdresserNotesForHairdressersResponseDto>> GetHairdresserNotesForHairdressersDetailsAsync(int hairdressersId, int hairdresserNotesId)
        {
            var returnValue = await _repository.GetHairdresserNotesForHairdressersDetailsAsync(hairdressersId, hairdresserNotesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ActivateAsync(int hairdresserId, ActivateRequestDto updateRequest)
        {
            var returnValue = await _repository.ActivateAsync(hairdresserId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int hairdresserId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(hairdresserId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}