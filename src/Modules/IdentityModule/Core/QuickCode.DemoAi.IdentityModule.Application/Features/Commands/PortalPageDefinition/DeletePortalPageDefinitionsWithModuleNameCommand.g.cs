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
    public class DeletePortalPageDefinitionsWithModuleNameCommand : IRequest<Response<int>>
    {
        public string PortalPageDefinitionModuleName { get; set; }

        public DeletePortalPageDefinitionsWithModuleNameCommand(string portalPageDefinitionModuleName)
        {
            this.PortalPageDefinitionModuleName = portalPageDefinitionModuleName;
        }

        public class DeletePortalPageDefinitionsWithModuleNameHandler : IRequestHandler<DeletePortalPageDefinitionsWithModuleNameCommand, Response<int>>
        {
            private readonly ILogger<DeletePortalPageDefinitionsWithModuleNameHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public DeletePortalPageDefinitionsWithModuleNameHandler(ILogger<DeletePortalPageDefinitionsWithModuleNameHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(DeletePortalPageDefinitionsWithModuleNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.DeletePortalPageDefinitionsWithModuleNameAsync(request.PortalPageDefinitionModuleName);
                return returnValue.ToResponse();
            }
        }
    }
}