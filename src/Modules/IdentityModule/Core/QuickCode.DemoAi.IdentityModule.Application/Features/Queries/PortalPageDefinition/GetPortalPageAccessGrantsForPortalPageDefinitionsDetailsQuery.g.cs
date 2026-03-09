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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.PortalPageDefinition;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.PortalPageDefinition
{
    public class GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsQuery : IRequest<Response<GetPortalPageAccessGrantsForPortalPageDefinitionsResponseDto>>
    {
        public string PortalPageDefinitionsKey { get; set; }
        public string PortalPageAccessGrantsPermissionGroupName { get; set; }

        public GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsQuery(string portalPageDefinitionsKey, string portalPageAccessGrantsPermissionGroupName)
        {
            this.PortalPageDefinitionsKey = portalPageDefinitionsKey;
            this.PortalPageAccessGrantsPermissionGroupName = portalPageAccessGrantsPermissionGroupName;
        }

        public class GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsHandler : IRequestHandler<GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsQuery, Response<GetPortalPageAccessGrantsForPortalPageDefinitionsResponseDto>>
        {
            private readonly ILogger<GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsHandler(ILogger<GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetPortalPageAccessGrantsForPortalPageDefinitionsResponseDto>> Handle(GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsAsync(request.PortalPageDefinitionsKey, request.PortalPageAccessGrantsPermissionGroupName);
                return returnValue.ToResponse();
            }
        }
    }
}