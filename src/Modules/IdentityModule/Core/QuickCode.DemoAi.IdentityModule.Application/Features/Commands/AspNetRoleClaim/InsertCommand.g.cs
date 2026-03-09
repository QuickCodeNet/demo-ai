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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.AspNetRoleClaim;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.AspNetRoleClaim
{
    public class InsertAspNetRoleClaimCommand : IRequest<Response<AspNetRoleClaimDto>>
    {
        public AspNetRoleClaimDto request { get; set; }

        public InsertAspNetRoleClaimCommand(AspNetRoleClaimDto request)
        {
            this.request = request;
        }

        public class InsertAspNetRoleClaimHandler : IRequestHandler<InsertAspNetRoleClaimCommand, Response<AspNetRoleClaimDto>>
        {
            private readonly ILogger<InsertAspNetRoleClaimHandler> _logger;
            private readonly IAspNetRoleClaimRepository _repository;
            public InsertAspNetRoleClaimHandler(ILogger<InsertAspNetRoleClaimHandler> logger, IAspNetRoleClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetRoleClaimDto>> Handle(InsertAspNetRoleClaimCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}