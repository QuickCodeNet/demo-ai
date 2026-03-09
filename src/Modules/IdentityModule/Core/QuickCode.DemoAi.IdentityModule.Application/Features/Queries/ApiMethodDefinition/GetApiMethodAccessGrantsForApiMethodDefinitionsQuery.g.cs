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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.ApiMethodDefinition;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.ApiMethodDefinition
{
    public class GetApiMethodAccessGrantsForApiMethodDefinitionsQuery : IRequest<Response<List<GetApiMethodAccessGrantsForApiMethodDefinitionsResponseDto>>>
    {
        public string ApiMethodDefinitionsKey { get; set; }

        public GetApiMethodAccessGrantsForApiMethodDefinitionsQuery(string apiMethodDefinitionsKey)
        {
            this.ApiMethodDefinitionsKey = apiMethodDefinitionsKey;
        }

        public class GetApiMethodAccessGrantsForApiMethodDefinitionsHandler : IRequestHandler<GetApiMethodAccessGrantsForApiMethodDefinitionsQuery, Response<List<GetApiMethodAccessGrantsForApiMethodDefinitionsResponseDto>>>
        {
            private readonly ILogger<GetApiMethodAccessGrantsForApiMethodDefinitionsHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public GetApiMethodAccessGrantsForApiMethodDefinitionsHandler(ILogger<GetApiMethodAccessGrantsForApiMethodDefinitionsHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetApiMethodAccessGrantsForApiMethodDefinitionsResponseDto>>> Handle(GetApiMethodAccessGrantsForApiMethodDefinitionsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetApiMethodAccessGrantsForApiMethodDefinitionsAsync(request.ApiMethodDefinitionsKey);
                return returnValue.ToResponse();
            }
        }
    }
}