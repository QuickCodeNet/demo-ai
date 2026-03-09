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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.AspNetRole;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.AspNetRole
{
    public class GetAspNetUserRolesForAspNetRolesQuery : IRequest<Response<List<GetAspNetUserRolesForAspNetRolesResponseDto>>>
    {
        public string AspNetRolesId { get; set; }

        public GetAspNetUserRolesForAspNetRolesQuery(string aspNetRolesId)
        {
            this.AspNetRolesId = aspNetRolesId;
        }

        public class GetAspNetUserRolesForAspNetRolesHandler : IRequestHandler<GetAspNetUserRolesForAspNetRolesQuery, Response<List<GetAspNetUserRolesForAspNetRolesResponseDto>>>
        {
            private readonly ILogger<GetAspNetUserRolesForAspNetRolesHandler> _logger;
            private readonly IAspNetRoleRepository _repository;
            public GetAspNetUserRolesForAspNetRolesHandler(ILogger<GetAspNetUserRolesForAspNetRolesHandler> logger, IAspNetRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetAspNetUserRolesForAspNetRolesResponseDto>>> Handle(GetAspNetUserRolesForAspNetRolesQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUserRolesForAspNetRolesAsync(request.AspNetRolesId);
                return returnValue.ToResponse();
            }
        }
    }
}