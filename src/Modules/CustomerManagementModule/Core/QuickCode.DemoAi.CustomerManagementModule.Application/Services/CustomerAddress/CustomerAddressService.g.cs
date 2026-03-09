using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoAi.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.CustomerAddress;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Application.Services.CustomerAddress
{
    public partial class CustomerAddressService : ICustomerAddressService
    {
        private readonly ILogger<CustomerAddressService> _logger;
        private readonly ICustomerAddressRepository _repository;
        public CustomerAddressService(ILogger<CustomerAddressService> logger, ICustomerAddressRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CustomerAddressDto>> InsertAsync(CustomerAddressDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CustomerAddressDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CustomerAddressDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CustomerAddressDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CustomerAddressDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int customerAddressCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerIdAsync(customerAddressCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetDefaultByCustomerResponseDto>> GetDefaultByCustomerAsync(int customerAddressCustomerId, bool? customerAddressIsDefault)
        {
            var returnValue = await _repository.GetDefaultByCustomerAsync(customerAddressCustomerId, customerAddressIsDefault);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> SetDefaultAsync(int customerAddressId, SetDefaultRequestDto updateRequest)
        {
            var returnValue = await _repository.SetDefaultAsync(customerAddressId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}