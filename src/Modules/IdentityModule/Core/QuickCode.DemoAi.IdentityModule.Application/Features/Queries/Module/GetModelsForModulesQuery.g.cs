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
    public class GetModelsForModulesQuery : IRequest<Response<List<GetModelsForModulesResponseDto>>>
    {
        public string ModulesName { get; set; }

        public GetModelsForModulesQuery(string modulesName)
        {
            this.ModulesName = modulesName;
        }

        public class GetModelsForModulesHandler : IRequestHandler<GetModelsForModulesQuery, Response<List<GetModelsForModulesResponseDto>>>
        {
            private readonly ILogger<GetModelsForModulesHandler> _logger;
            private readonly IModuleRepository _repository;
            public GetModelsForModulesHandler(ILogger<GetModelsForModulesHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetModelsForModulesResponseDto>>> Handle(GetModelsForModulesQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetModelsForModulesAsync(request.ModulesName);
                return returnValue.ToResponse();
            }
        }
    }
}