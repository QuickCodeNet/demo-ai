using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Entities;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.HairdresserManagementModule.Application.Dtos.HairdresserNote;
using QuickCode.DemoAi.HairdresserManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.HairdresserManagementModule.Application.Services.HairdresserNote
{
    public partial interface IHairdresserNoteService
    {
        Task<Response<HairdresserNoteDto>> InsertAsync(HairdresserNoteDto request);
        Task<Response<bool>> DeleteAsync(HairdresserNoteDto request);
        Task<Response<bool>> UpdateAsync(int id, HairdresserNoteDto request);
        Task<Response<List<HairdresserNoteDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<HairdresserNoteDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByHairdresserIdResponseDto>>> GetByHairdresserIdAsync(int hairdresserNoteHairdresserId, int? page, int? size);
    }
}