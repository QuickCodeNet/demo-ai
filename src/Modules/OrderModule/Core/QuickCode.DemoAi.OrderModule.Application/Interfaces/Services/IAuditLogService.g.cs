using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.OrderModule.Domain.Entities;
using QuickCode.DemoAi.OrderModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.OrderModule.Application.Dtos.AuditLog;
using QuickCode.DemoAi.OrderModule.Domain.Enums;

namespace QuickCode.DemoAi.OrderModule.Application.Services.AuditLog
{
    public partial interface IAuditLogService
    {
        Task<Response<AuditLogDto>> InsertAsync(AuditLogDto request);
        Task<Response<bool>> DeleteAsync(AuditLogDto request);
        Task<Response<bool>> UpdateAsync(Guid id, AuditLogDto request);
        Task<Response<List<AuditLogDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AuditLogDto>> GetItemAsync(Guid id);
        Task<Response<bool>> DeleteItemAsync(Guid id);
        Task<Response<int>> TotalItemCountAsync();
    }
}