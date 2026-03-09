using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.SalonEquipment;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Services.SalonEquipment
{
    public partial class SalonEquipmentService : ISalonEquipmentService
    {
        private readonly ILogger<SalonEquipmentService> _logger;
        private readonly ISalonEquipmentRepository _repository;
        public SalonEquipmentService(ILogger<SalonEquipmentService> logger, ISalonEquipmentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<SalonEquipmentDto>> InsertAsync(SalonEquipmentDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(SalonEquipmentDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, SalonEquipmentDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SalonEquipmentDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<SalonEquipmentDto>> GetItemAsync(int id)
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

        public async Task<Response<int>> UpdateQuantityAsync(int salonEquipmentId, UpdateQuantityRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateQuantityAsync(salonEquipmentId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}