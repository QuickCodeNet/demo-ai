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
    public partial interface ICustomerNoteService
    {
        Task<Response<CustomerNoteDto>> InsertAsync(CustomerNoteDto request);
        Task<Response<bool>> DeleteAsync(CustomerNoteDto request);
        Task<Response<bool>> UpdateAsync(int id, CustomerNoteDto request);
        Task<Response<List<CustomerNoteDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CustomerNoteDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int customerNoteCustomerId, int? page, int? size);
    }
}