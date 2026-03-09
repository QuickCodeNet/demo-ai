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
    public class InsertModelCommand : IRequest<Response<ModelDto>>
    {
        public ModelDto request { get; set; }

        public InsertModelCommand(ModelDto request)
        {
            this.request = request;
        }

        public class InsertModelHandler : IRequestHandler<InsertModelCommand, Response<ModelDto>>
        {
            private readonly ILogger<InsertModelHandler> _logger;
            private readonly IModelRepository _repository;
            public InsertModelHandler(ILogger<InsertModelHandler> logger, IModelRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<ModelDto>> Handle(InsertModelCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}