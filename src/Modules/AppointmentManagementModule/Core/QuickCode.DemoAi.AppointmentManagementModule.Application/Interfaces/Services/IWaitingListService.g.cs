using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.WaitingList;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Application.Services.WaitingList
{
    public partial interface IWaitingListService
    {
        Task<Response<WaitingListDto>> InsertAsync(WaitingListDto request);
        Task<Response<bool>> DeleteAsync(WaitingListDto request);
        Task<Response<bool>> UpdateAsync(int id, WaitingListDto request);
        Task<Response<List<WaitingListDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<WaitingListDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByServiceIdResponseDto>>> GetByServiceIdAsync(int waitingListServiceId, int? page, int? size);
    }
}