using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.Holiday;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Application.Services.Holiday
{
    public partial interface IHolidayService
    {
        Task<Response<HolidayDto>> InsertAsync(HolidayDto request);
        Task<Response<bool>> DeleteAsync(HolidayDto request);
        Task<Response<bool>> UpdateAsync(int id, HolidayDto request);
        Task<Response<List<HolidayDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<HolidayDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetAllResponseDto>>> GetAllAsync();
    }
}