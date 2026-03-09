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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.PermissionGroup;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.PermissionGroup
{
    public class ListPermissionGroupQuery : IRequest<Response<List<PermissionGroupDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public ListPermissionGroupQuery(int? pageNumber, int? pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        public class ListPermissionGroupHandler : IRequestHandler<ListPermissionGroupQuery, Response<List<PermissionGroupDto>>>
        {
            private readonly ILogger<ListPermissionGroupHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public ListPermissionGroupHandler(ILogger<ListPermissionGroupHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<PermissionGroupDto>>> Handle(ListPermissionGroupQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ListAsync(request.PageNumber, request.PageSize);
                return returnValue.ToResponse();
            }
        }
    }
}