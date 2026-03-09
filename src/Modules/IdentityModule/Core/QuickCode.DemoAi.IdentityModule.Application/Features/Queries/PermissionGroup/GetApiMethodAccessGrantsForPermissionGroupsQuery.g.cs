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
    public class GetApiMethodAccessGrantsForPermissionGroupsQuery : IRequest<Response<List<GetApiMethodAccessGrantsForPermissionGroupsResponseDto>>>
    {
        public string PermissionGroupsName { get; set; }

        public GetApiMethodAccessGrantsForPermissionGroupsQuery(string permissionGroupsName)
        {
            this.PermissionGroupsName = permissionGroupsName;
        }

        public class GetApiMethodAccessGrantsForPermissionGroupsHandler : IRequestHandler<GetApiMethodAccessGrantsForPermissionGroupsQuery, Response<List<GetApiMethodAccessGrantsForPermissionGroupsResponseDto>>>
        {
            private readonly ILogger<GetApiMethodAccessGrantsForPermissionGroupsHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public GetApiMethodAccessGrantsForPermissionGroupsHandler(ILogger<GetApiMethodAccessGrantsForPermissionGroupsHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetApiMethodAccessGrantsForPermissionGroupsResponseDto>>> Handle(GetApiMethodAccessGrantsForPermissionGroupsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetApiMethodAccessGrantsForPermissionGroupsAsync(request.PermissionGroupsName);
                return returnValue.ToResponse();
            }
        }
    }
}