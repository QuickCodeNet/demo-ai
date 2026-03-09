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
    public class ExistsApiMethodDefinitionsWithModuleNameQuery : IRequest<Response<bool>>
    {
        public string ApiMethodDefinitionModuleName { get; set; }

        public ExistsApiMethodDefinitionsWithModuleNameQuery(string apiMethodDefinitionModuleName)
        {
            this.ApiMethodDefinitionModuleName = apiMethodDefinitionModuleName;
        }

        public class ExistsApiMethodDefinitionsWithModuleNameHandler : IRequestHandler<ExistsApiMethodDefinitionsWithModuleNameQuery, Response<bool>>
        {
            private readonly ILogger<ExistsApiMethodDefinitionsWithModuleNameHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public ExistsApiMethodDefinitionsWithModuleNameHandler(ILogger<ExistsApiMethodDefinitionsWithModuleNameHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(ExistsApiMethodDefinitionsWithModuleNameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ExistsApiMethodDefinitionsWithModuleNameAsync(request.ApiMethodDefinitionModuleName);
                return returnValue.ToResponse();
            }
        }
    }
}