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
    public class GetAspNetUsersForPermissionGroupsQuery : IRequest<Response<List<GetAspNetUsersForPermissionGroupsResponseDto>>>
    {
        public string PermissionGroupsName { get; set; }

        public GetAspNetUsersForPermissionGroupsQuery(string permissionGroupsName)
        {
            this.PermissionGroupsName = permissionGroupsName;
        }

        public class GetAspNetUsersForPermissionGroupsHandler : IRequestHandler<GetAspNetUsersForPermissionGroupsQuery, Response<List<GetAspNetUsersForPermissionGroupsResponseDto>>>
        {
            private readonly ILogger<GetAspNetUsersForPermissionGroupsHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public GetAspNetUsersForPermissionGroupsHandler(ILogger<GetAspNetUsersForPermissionGroupsHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetAspNetUsersForPermissionGroupsResponseDto>>> Handle(GetAspNetUsersForPermissionGroupsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUsersForPermissionGroupsAsync(request.PermissionGroupsName);
                return returnValue.ToResponse();
            }
        }
    }
}