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
    public class GetItemAspNetUserRoleQuery : IRequest<Response<AspNetUserRoleDto>>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public GetItemAspNetUserRoleQuery(string userId, string roleId)
        {
            this.UserId = userId;
            this.RoleId = roleId;
        }

        public class GetItemAspNetUserRoleHandler : IRequestHandler<GetItemAspNetUserRoleQuery, Response<AspNetUserRoleDto>>
        {
            private readonly ILogger<GetItemAspNetUserRoleHandler> _logger;
            private readonly IAspNetUserRoleRepository _repository;
            public GetItemAspNetUserRoleHandler(ILogger<GetItemAspNetUserRoleHandler> logger, IAspNetUserRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserRoleDto>> Handle(GetItemAspNetUserRoleQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.UserId, request.RoleId);
                return returnValue.ToResponse();
            }
        }
    }
}