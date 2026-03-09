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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.Model;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.Model
{
    public class GetPortalPageDefinitionsForModelsQuery : IRequest<Response<List<GetPortalPageDefinitionsForModelsResponseDto>>>
    {
        public string ModelsName { get; set; }

        public GetPortalPageDefinitionsForModelsQuery(string modelsName)
        {
            this.ModelsName = modelsName;
        }

        public class GetPortalPageDefinitionsForModelsHandler : IRequestHandler<GetPortalPageDefinitionsForModelsQuery, Response<List<GetPortalPageDefinitionsForModelsResponseDto>>>
        {
            private readonly ILogger<GetPortalPageDefinitionsForModelsHandler> _logger;
            private readonly IModelRepository _repository;
            public GetPortalPageDefinitionsForModelsHandler(ILogger<GetPortalPageDefinitionsForModelsHandler> logger, IModelRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetPortalPageDefinitionsForModelsResponseDto>>> Handle(GetPortalPageDefinitionsForModelsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageDefinitionsForModelsAsync(request.ModelsName);
                return returnValue.ToResponse();
            }
        }
    }
}