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
    public class DeleteModuleCommand : IRequest<Response<bool>>
    {
        public ModuleDto request { get; set; }

        public DeleteModuleCommand(ModuleDto request)
        {
            this.request = request;
        }

        public class DeleteModuleHandler : IRequestHandler<DeleteModuleCommand, Response<bool>>
        {
            private readonly ILogger<DeleteModuleHandler> _logger;
            private readonly IModuleRepository _repository;
            public DeleteModuleHandler(ILogger<DeleteModuleHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}