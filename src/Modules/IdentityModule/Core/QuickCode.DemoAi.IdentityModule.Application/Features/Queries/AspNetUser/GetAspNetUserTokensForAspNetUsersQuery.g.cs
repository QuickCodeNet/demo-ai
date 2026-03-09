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
    public class GetAspNetUserTokensForAspNetUsersQuery : IRequest<Response<List<GetAspNetUserTokensForAspNetUsersResponseDto>>>
    {
        public string AspNetUsersId { get; set; }

        public GetAspNetUserTokensForAspNetUsersQuery(string aspNetUsersId)
        {
            this.AspNetUsersId = aspNetUsersId;
        }

        public class GetAspNetUserTokensForAspNetUsersHandler : IRequestHandler<GetAspNetUserTokensForAspNetUsersQuery, Response<List<GetAspNetUserTokensForAspNetUsersResponseDto>>>
        {
            private readonly ILogger<GetAspNetUserTokensForAspNetUsersHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetAspNetUserTokensForAspNetUsersHandler(ILogger<GetAspNetUserTokensForAspNetUsersHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetAspNetUserTokensForAspNetUsersResponseDto>>> Handle(GetAspNetUserTokensForAspNetUsersQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUserTokensForAspNetUsersAsync(request.AspNetUsersId);
                return returnValue.ToResponse();
            }
        }
    }
}