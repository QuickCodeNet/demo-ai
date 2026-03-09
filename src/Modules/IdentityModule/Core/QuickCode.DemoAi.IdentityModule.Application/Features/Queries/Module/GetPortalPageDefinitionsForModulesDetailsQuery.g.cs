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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.Module;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.Module
{
    public class GetPortalPageDefinitionsForModulesDetailsQuery : IRequest<Response<GetPortalPageDefinitionsForModulesResponseDto>>
    {
        public string ModulesName { get; set; }
        public string PortalPageDefinitionsKey { get; set; }

        public GetPortalPageDefinitionsForModulesDetailsQuery(string modulesName, string portalPageDefinitionsKey)
        {
            this.ModulesName = modulesName;
            this.PortalPageDefinitionsKey = portalPageDefinitionsKey;
        }

        public class GetPortalPageDefinitionsForModulesDetailsHandler : IRequestHandler<GetPortalPageDefinitionsForModulesDetailsQuery, Response<GetPortalPageDefinitionsForModulesResponseDto>>
        {
            private readonly ILogger<GetPortalPageDefinitionsForModulesDetailsHandler> _logger;
            private readonly IModuleRepository _repository;
            public GetPortalPageDefinitionsForModulesDetailsHandler(ILogger<GetPortalPageDefinitionsForModulesDetailsHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetPortalPageDefinitionsForModulesResponseDto>> Handle(GetPortalPageDefinitionsForModulesDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageDefinitionsForModulesDetailsAsync(request.ModulesName, request.PortalPageDefinitionsKey);
                return returnValue.ToResponse();
            }
        }
    }
}