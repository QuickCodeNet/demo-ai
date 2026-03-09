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
    public class GetPortalPageAccessGrantsForPortalPageDefinitionsQuery : IRequest<Response<List<GetPortalPageAccessGrantsForPortalPageDefinitionsResponseDto>>>
    {
        public string PortalPageDefinitionsKey { get; set; }

        public GetPortalPageAccessGrantsForPortalPageDefinitionsQuery(string portalPageDefinitionsKey)
        {
            this.PortalPageDefinitionsKey = portalPageDefinitionsKey;
        }

        public class GetPortalPageAccessGrantsForPortalPageDefinitionsHandler : IRequestHandler<GetPortalPageAccessGrantsForPortalPageDefinitionsQuery, Response<List<GetPortalPageAccessGrantsForPortalPageDefinitionsResponseDto>>>
        {
            private readonly ILogger<GetPortalPageAccessGrantsForPortalPageDefinitionsHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public GetPortalPageAccessGrantsForPortalPageDefinitionsHandler(ILogger<GetPortalPageAccessGrantsForPortalPageDefinitionsHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetPortalPageAccessGrantsForPortalPageDefinitionsResponseDto>>> Handle(GetPortalPageAccessGrantsForPortalPageDefinitionsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageAccessGrantsForPortalPageDefinitionsAsync(request.PortalPageDefinitionsKey);
                return returnValue.ToResponse();
            }
        }
    }
}