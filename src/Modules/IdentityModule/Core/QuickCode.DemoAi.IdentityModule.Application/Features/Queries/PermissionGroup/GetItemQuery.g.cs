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
    public class GetItemPermissionGroupQuery : IRequest<Response<PermissionGroupDto>>
    {
        public string Name { get; set; }

        public GetItemPermissionGroupQuery(string name)
        {
            this.Name = name;
        }

        public class GetItemPermissionGroupHandler : IRequestHandler<GetItemPermissionGroupQuery, Response<PermissionGroupDto>>
        {
            private readonly ILogger<GetItemPermissionGroupHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public GetItemPermissionGroupHandler(ILogger<GetItemPermissionGroupHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<PermissionGroupDto>> Handle(GetItemPermissionGroupQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Name);
                return returnValue.ToResponse();
            }
        }
    }
}