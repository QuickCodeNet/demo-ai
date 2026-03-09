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
    public class DeletePortalPageDefinitionsWithModelNameCommand : IRequest<Response<int>>
    {
        public string PortalPageDefinitionModelName { get; set; }

        public DeletePortalPageDefinitionsWithModelNameCommand(string portalPageDefinitionModelName)
        {
            this.PortalPageDefinitionModelName = portalPageDefinitionModelName;
        }

        public class DeletePortalPageDefinitionsWithModelNameHandler : IRequestHandler<DeletePortalPageDefinitionsWithModelNameCommand, Response<int>>
        {
            private readonly ILogger<DeletePortalPageDefinitionsWithModelNameHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public DeletePortalPageDefinitionsWithModelNameHandler(ILogger<DeletePortalPageDefinitionsWithModelNameHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(DeletePortalPageDefinitionsWithModelNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.DeletePortalPageDefinitionsWithModelNameAsync(request.PortalPageDefinitionModelName);
                return returnValue.ToResponse();
            }
        }
    }
}