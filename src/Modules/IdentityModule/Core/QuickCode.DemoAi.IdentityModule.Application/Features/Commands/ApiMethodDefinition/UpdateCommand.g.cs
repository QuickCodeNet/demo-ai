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
    public class UpdateApiMethodDefinitionCommand : IRequest<Response<bool>>
    {
        public string Key { get; set; }
        public ApiMethodDefinitionDto request { get; set; }

        public UpdateApiMethodDefinitionCommand(string key, ApiMethodDefinitionDto request)
        {
            this.request = request;
            this.Key = key;
        }

        public class UpdateApiMethodDefinitionHandler : IRequestHandler<UpdateApiMethodDefinitionCommand, Response<bool>>
        {
            private readonly ILogger<UpdateApiMethodDefinitionHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public UpdateApiMethodDefinitionHandler(ILogger<UpdateApiMethodDefinitionHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateApiMethodDefinitionCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Key);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}