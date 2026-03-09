using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoAi.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.CustomerManagementModule.Application.Dtos.CustomerNote;
using QuickCode.DemoAi.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.CustomerManagementModule.Application.Services.CustomerNote
{
    public partial class CustomerNoteService : ICustomerNoteService
    {
        private readonly ILogger<CustomerNoteService> _logger;
        private readonly ICustomerNoteRepository _repository;
        public CustomerNoteService(ILogger<CustomerNoteService> logger, ICustomerNoteRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CustomerNoteDto>> InsertAsync(CustomerNoteDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CustomerNoteDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CustomerNoteDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CustomerNoteDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CustomerNoteDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int customerNoteCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerIdAsync(customerNoteCustomerId, page, size);
            return returnValue.ToResponse();
        }
    }
}