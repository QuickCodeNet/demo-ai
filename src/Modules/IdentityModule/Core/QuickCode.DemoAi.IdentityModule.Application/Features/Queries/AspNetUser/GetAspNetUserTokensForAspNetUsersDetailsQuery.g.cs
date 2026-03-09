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
    public class GetAspNetUserTokensForAspNetUsersDetailsQuery : IRequest<Response<GetAspNetUserTokensForAspNetUsersResponseDto>>
    {
        public string AspNetUsersId { get; set; }
        public string AspNetUserTokensUserId { get; set; }

        public GetAspNetUserTokensForAspNetUsersDetailsQuery(string aspNetUsersId, string aspNetUserTokensUserId)
        {
            this.AspNetUsersId = aspNetUsersId;
            this.AspNetUserTokensUserId = aspNetUserTokensUserId;
        }

        public class GetAspNetUserTokensForAspNetUsersDetailsHandler : IRequestHandler<GetAspNetUserTokensForAspNetUsersDetailsQuery, Response<GetAspNetUserTokensForAspNetUsersResponseDto>>
        {
            private readonly ILogger<GetAspNetUserTokensForAspNetUsersDetailsHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetAspNetUserTokensForAspNetUsersDetailsHandler(ILogger<GetAspNetUserTokensForAspNetUsersDetailsHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetAspNetUserTokensForAspNetUsersResponseDto>> Handle(GetAspNetUserTokensForAspNetUsersDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUserTokensForAspNetUsersDetailsAsync(request.AspNetUsersId, request.AspNetUserTokensUserId);
                return returnValue.ToResponse();
            }
        }
    }
}