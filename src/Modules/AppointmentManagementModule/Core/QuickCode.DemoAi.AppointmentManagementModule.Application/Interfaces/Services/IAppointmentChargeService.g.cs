using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Entities;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.AppointmentManagementModule.Application.Dtos.AppointmentCharge;
using QuickCode.DemoAi.AppointmentManagementModule.Domain.Enums;

namespace QuickCode.DemoAi.AppointmentManagementModule.Application.Services.AppointmentCharge
{
    public partial interface IAppointmentChargeService
    {
        Task<Response<AppointmentChargeDto>> InsertAsync(AppointmentChargeDto request);
        Task<Response<bool>> DeleteAsync(AppointmentChargeDto request);
        Task<Response<bool>> UpdateAsync(int id, AppointmentChargeDto request);
        Task<Response<List<AppointmentChargeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AppointmentChargeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByAppointmentIdResponseDto>>> GetByAppointmentIdAsync(int appointmentChargeAppointmentId, int? page, int? size);
    }
}