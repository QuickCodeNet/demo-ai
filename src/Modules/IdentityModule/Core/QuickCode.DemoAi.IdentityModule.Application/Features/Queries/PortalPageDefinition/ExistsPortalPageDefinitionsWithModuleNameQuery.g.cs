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
    public class ExistsPortalPageDefinitionsWithModuleNameQuery : IRequest<Response<bool>>
    {
        public string PortalPageDefinitionModuleName { get; set; }

        public ExistsPortalPageDefinitionsWithModuleNameQuery(string portalPageDefinitionModuleName)
        {
            this.PortalPageDefinitionModuleName = portalPageDefinitionModuleName;
        }

        public class ExistsPortalPageDefinitionsWithModuleNameHandler : IRequestHandler<ExistsPortalPageDefinitionsWithModuleNameQuery, Response<bool>>
        {
            private readonly ILogger<ExistsPortalPageDefinitionsWithModuleNameHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public ExistsPortalPageDefinitionsWithModuleNameHandler(ILogger<ExistsPortalPageDefinitionsWithModuleNameHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(ExistsPortalPageDefinitionsWithModuleNameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ExistsPortalPageDefinitionsWithModuleNameAsync(request.PortalPageDefinitionModuleName);
                return returnValue.ToResponse();
            }
        }
    }
}