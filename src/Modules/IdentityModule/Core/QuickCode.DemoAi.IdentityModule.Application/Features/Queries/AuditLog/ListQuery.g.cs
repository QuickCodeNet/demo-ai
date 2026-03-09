using System;
using System.Linq;
using QuickCode.DemoAi.Common.Mediator;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoAi.Common.Models;
using QuickCode.DemoAi.IdentityModule.Domain.Entities;
using QuickCode.DemoAi.IdentityModule.Application.Interfaces.Repositories;
using QuickCode.DemoAi.IdentityModule.Application.Dtos.AuditLog;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.AuditLog
{
    public class ListAuditLogQuery : IRequest<Response<List<AuditLogDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public ListAuditLogQuery(int? pageNumber, int? pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        public class ListAuditLogHandler : IRequestHandler<ListAuditLogQuery, Response<List<AuditLogDto>>>
        {
            private readonly ILogger<ListAuditLogHandler> _logger;
            private readonly IAuditLogRepository _repository;
            public ListAuditLogHandler(ILogger<ListAuditLogHandler> logger, IAuditLogRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<AuditLogDto>>> Handle(ListAuditLogQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ListAsync(request.PageNumber, request.PageSize);
                return returnValue.ToResponse();
            }
        }
    }
}