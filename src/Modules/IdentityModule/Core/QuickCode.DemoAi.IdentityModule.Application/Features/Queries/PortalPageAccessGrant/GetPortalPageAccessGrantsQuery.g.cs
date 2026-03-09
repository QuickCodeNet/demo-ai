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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.PortalPageAccessGrant;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.PortalPageAccessGrant
{
    public class GetPortalPageAccessGrantsQuery : IRequest<Response<List<GetPortalPageAccessGrantsResponseDto>>>
    {
        public string PortalPageAccessGrantPermissionGroupName { get; set; }

        public GetPortalPageAccessGrantsQuery(string portalPageAccessGrantPermissionGroupName)
        {
            this.PortalPageAccessGrantPermissionGroupName = portalPageAccessGrantPermissionGroupName;
        }

        public class GetPortalPageAccessGrantsHandler : IRequestHandler<GetPortalPageAccessGrantsQuery, Response<List<GetPortalPageAccessGrantsResponseDto>>>
        {
            private readonly ILogger<GetPortalPageAccessGrantsHandler> _logger;
            private readonly IPortalPageAccessGrantRepository _repository;
            public GetPortalPageAccessGrantsHandler(ILogger<GetPortalPageAccessGrantsHandler> logger, IPortalPageAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetPortalPageAccessGrantsResponseDto>>> Handle(GetPortalPageAccessGrantsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageAccessGrantsAsync(request.PortalPageAccessGrantPermissionGroupName);
                return returnValue.ToResponse();
            }
        }
    }
}