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
    public class GetItemAspNetRoleClaimQuery : IRequest<Response<AspNetRoleClaimDto>>
    {
        public int Id { get; set; }

        public GetItemAspNetRoleClaimQuery(int id)
        {
            this.Id = id;
        }

        public class GetItemAspNetRoleClaimHandler : IRequestHandler<GetItemAspNetRoleClaimQuery, Response<AspNetRoleClaimDto>>
        {
            private readonly ILogger<GetItemAspNetRoleClaimHandler> _logger;
            private readonly IAspNetRoleClaimRepository _repository;
            public GetItemAspNetRoleClaimHandler(ILogger<GetItemAspNetRoleClaimHandler> logger, IAspNetRoleClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetRoleClaimDto>> Handle(GetItemAspNetRoleClaimQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}