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
    public class GetItemPortalPageDefinitionQuery : IRequest<Response<PortalPageDefinitionDto>>
    {
        public string Key { get; set; }

        public GetItemPortalPageDefinitionQuery(string key)
        {
            this.Key = key;
        }

        public class GetItemPortalPageDefinitionHandler : IRequestHandler<GetItemPortalPageDefinitionQuery, Response<PortalPageDefinitionDto>>
        {
            private readonly ILogger<GetItemPortalPageDefinitionHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public GetItemPortalPageDefinitionHandler(ILogger<GetItemPortalPageDefinitionHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<PortalPageDefinitionDto>> Handle(GetItemPortalPageDefinitionQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Key);
                return returnValue.ToResponse();
            }
        }
    }
}