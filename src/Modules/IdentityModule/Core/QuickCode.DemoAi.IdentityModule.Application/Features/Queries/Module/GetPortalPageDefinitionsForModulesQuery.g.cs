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
    public class GetPortalPageDefinitionsForModulesQuery : IRequest<Response<List<GetPortalPageDefinitionsForModulesResponseDto>>>
    {
        public string ModulesName { get; set; }

        public GetPortalPageDefinitionsForModulesQuery(string modulesName)
        {
            this.ModulesName = modulesName;
        }

        public class GetPortalPageDefinitionsForModulesHandler : IRequestHandler<GetPortalPageDefinitionsForModulesQuery, Response<List<GetPortalPageDefinitionsForModulesResponseDto>>>
        {
            private readonly ILogger<GetPortalPageDefinitionsForModulesHandler> _logger;
            private readonly IModuleRepository _repository;
            public GetPortalPageDefinitionsForModulesHandler(ILogger<GetPortalPageDefinitionsForModulesHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetPortalPageDefinitionsForModulesResponseDto>>> Handle(GetPortalPageDefinitionsForModulesQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageDefinitionsForModulesAsync(request.ModulesName);
                return returnValue.ToResponse();
            }
        }
    }
}