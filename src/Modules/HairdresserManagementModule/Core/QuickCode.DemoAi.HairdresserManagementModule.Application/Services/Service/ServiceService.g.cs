using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.Service;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Services.Service
{
    public partial class ServiceService : IServiceService
    {
        private readonly ILogger<ServiceService> _logger;
        private readonly IServiceRepository _repository;
        public ServiceService(ILogger<ServiceService> logger, IServiceRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ServiceDto>> InsertAsync(ServiceDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ServiceDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ServiceDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ServiceDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ServiceDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByHairdresserIdResponseDto>>> GetByHairdresserIdAsync(int serviceHairdresserId, int? page, int? size)
        {
            var returnValue = await _repository.GetByHairdresserIdAsync(serviceHairdresserId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByCategoryResponseDto>>> GetByCategoryAsync(ServiceCategory serviceCategory, int? page, int? size)
        {
            var returnValue = await _repository.GetByCategoryAsync(serviceCategory, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetServicePricesForServicesResponseDto>>> GetServicePricesForServicesAsync(int servicesId)
        {
            var returnValue = await _repository.GetServicePricesForServicesAsync(servicesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetServicePricesForServicesResponseDto>> GetServicePricesForServicesDetailsAsync(int servicesId, int servicePricesId)
        {
            var returnValue = await _repository.GetServicePricesForServicesDetailsAsync(servicesId, servicePricesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdatePriceAsync(int serviceId, UpdatePriceRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdatePriceAsync(serviceId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}