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
    public class InsertModuleCommand : IRequest<Response<ModuleDto>>
    {
        public ModuleDto request { get; set; }

        public InsertModuleCommand(ModuleDto request)
        {
            this.request = request;
        }

        public class InsertModuleHandler : IRequestHandler<InsertModuleCommand, Response<ModuleDto>>
        {
            private readonly ILogger<InsertModuleHandler> _logger;
            private readonly IModuleRepository _repository;
            public InsertModuleHandler(ILogger<InsertModuleHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<ModuleDto>> Handle(InsertModuleCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}