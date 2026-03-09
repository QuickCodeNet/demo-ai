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
    public class GetAspNetUserLoginsForAspNetUsersQuery : IRequest<Response<List<GetAspNetUserLoginsForAspNetUsersResponseDto>>>
    {
        public string AspNetUsersId { get; set; }

        public GetAspNetUserLoginsForAspNetUsersQuery(string aspNetUsersId)
        {
            this.AspNetUsersId = aspNetUsersId;
        }

        public class GetAspNetUserLoginsForAspNetUsersHandler : IRequestHandler<GetAspNetUserLoginsForAspNetUsersQuery, Response<List<GetAspNetUserLoginsForAspNetUsersResponseDto>>>
        {
            private readonly ILogger<GetAspNetUserLoginsForAspNetUsersHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetAspNetUserLoginsForAspNetUsersHandler(ILogger<GetAspNetUserLoginsForAspNetUsersHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetAspNetUserLoginsForAspNetUsersResponseDto>>> Handle(GetAspNetUserLoginsForAspNetUsersQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUserLoginsForAspNetUsersAsync(request.AspNetUsersId);
                return returnValue.ToResponse();
            }
        }
    }
}