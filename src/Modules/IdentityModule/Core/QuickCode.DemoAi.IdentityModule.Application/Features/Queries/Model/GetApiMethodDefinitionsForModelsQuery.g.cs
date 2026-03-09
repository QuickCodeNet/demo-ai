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
    public class GetApiMethodDefinitionsForModelsQuery : IRequest<Response<List<GetApiMethodDefinitionsForModelsResponseDto>>>
    {
        public string ModelsName { get; set; }

        public GetApiMethodDefinitionsForModelsQuery(string modelsName)
        {
            this.ModelsName = modelsName;
        }

        public class GetApiMethodDefinitionsForModelsHandler : IRequestHandler<GetApiMethodDefinitionsForModelsQuery, Response<List<GetApiMethodDefinitionsForModelsResponseDto>>>
        {
            private readonly ILogger<GetApiMethodDefinitionsForModelsHandler> _logger;
            private readonly IModelRepository _repository;
            public GetApiMethodDefinitionsForModelsHandler(ILogger<GetApiMethodDefinitionsForModelsHandler> logger, IModelRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetApiMethodDefinitionsForModelsResponseDto>>> Handle(GetApiMethodDefinitionsForModelsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetApiMethodDefinitionsForModelsAsync(request.ModelsName);
                return returnValue.ToResponse();
            }
        }
    }
}