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
    public class GetPortalPageAccessGrantsForPermissionGroupsQuery : IRequest<Response<List<GetPortalPageAccessGrantsForPermissionGroupsResponseDto>>>
    {
        public string PermissionGroupsName { get; set; }

        public GetPortalPageAccessGrantsForPermissionGroupsQuery(string permissionGroupsName)
        {
            this.PermissionGroupsName = permissionGroupsName;
        }

        public class GetPortalPageAccessGrantsForPermissionGroupsHandler : IRequestHandler<GetPortalPageAccessGrantsForPermissionGroupsQuery, Response<List<GetPortalPageAccessGrantsForPermissionGroupsResponseDto>>>
        {
            private readonly ILogger<GetPortalPageAccessGrantsForPermissionGroupsHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public GetPortalPageAccessGrantsForPermissionGroupsHandler(ILogger<GetPortalPageAccessGrantsForPermissionGroupsHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetPortalPageAccessGrantsForPermissionGroupsResponseDto>>> Handle(GetPortalPageAccessGrantsForPermissionGroupsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageAccessGrantsForPermissionGroupsAsync(request.PermissionGroupsName);
                return returnValue.ToResponse();
            }
        }
    }
}