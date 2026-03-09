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
    public class UpdateModuleCommand : IRequest<Response<bool>>
    {
        public string Name { get; set; }
        public ModuleDto request { get; set; }

        public UpdateModuleCommand(string name, ModuleDto request)
        {
            this.request = request;
            this.Name = name;
        }

        public class UpdateModuleHandler : IRequestHandler<UpdateModuleCommand, Response<bool>>
        {
            private readonly ILogger<UpdateModuleHandler> _logger;
            private readonly IModuleRepository _repository;
            public UpdateModuleHandler(ILogger<UpdateModuleHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Name);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}