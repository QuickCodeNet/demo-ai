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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.AspNetUserRole;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.AspNetUserRole
{
    public class TotalCountAspNetUserRoleQuery : IRequest<Response<int>>
    {
        public TotalCountAspNetUserRoleQuery()
        {
        }

        public class TotalCountAspNetUserRoleHandler : IRequestHandler<TotalCountAspNetUserRoleQuery, Response<int>>
        {
            private readonly ILogger<TotalCountAspNetUserRoleHandler> _logger;
            private readonly IAspNetUserRoleRepository _repository;
            public TotalCountAspNetUserRoleHandler(ILogger<TotalCountAspNetUserRoleHandler> logger, IAspNetUserRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountAspNetUserRoleQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}