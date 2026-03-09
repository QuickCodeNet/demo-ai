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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.AspNetUserLogin;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.AspNetUserLogin
{
    public class InsertAspNetUserLoginCommand : IRequest<Response<AspNetUserLoginDto>>
    {
        public AspNetUserLoginDto request { get; set; }

        public InsertAspNetUserLoginCommand(AspNetUserLoginDto request)
        {
            this.request = request;
        }

        public class InsertAspNetUserLoginHandler : IRequestHandler<InsertAspNetUserLoginCommand, Response<AspNetUserLoginDto>>
        {
            private readonly ILogger<InsertAspNetUserLoginHandler> _logger;
            private readonly IAspNetUserLoginRepository _repository;
            public InsertAspNetUserLoginHandler(ILogger<InsertAspNetUserLoginHandler> logger, IAspNetUserLoginRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserLoginDto>> Handle(InsertAspNetUserLoginCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}