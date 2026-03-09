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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.AspNetUser;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.AspNetUser
{
    public class GetAspNetUserRolesForAspNetUsersQuery : IRequest<Response<List<GetAspNetUserRolesForAspNetUsersResponseDto>>>
    {
        public string AspNetUsersId { get; set; }

        public GetAspNetUserRolesForAspNetUsersQuery(string aspNetUsersId)
        {
            this.AspNetUsersId = aspNetUsersId;
        }

        public class GetAspNetUserRolesForAspNetUsersHandler : IRequestHandler<GetAspNetUserRolesForAspNetUsersQuery, Response<List<GetAspNetUserRolesForAspNetUsersResponseDto>>>
        {
            private readonly ILogger<GetAspNetUserRolesForAspNetUsersHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetAspNetUserRolesForAspNetUsersHandler(ILogger<GetAspNetUserRolesForAspNetUsersHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetAspNetUserRolesForAspNetUsersResponseDto>>> Handle(GetAspNetUserRolesForAspNetUsersQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUserRolesForAspNetUsersAsync(request.AspNetUsersId);
                return returnValue.ToResponse();
            }
        }
    }
}