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
    public class GetAspNetUserClaimsForAspNetUsersDetailsQuery : IRequest<Response<GetAspNetUserClaimsForAspNetUsersResponseDto>>
    {
        public string AspNetUsersId { get; set; }
        public int AspNetUserClaimsId { get; set; }

        public GetAspNetUserClaimsForAspNetUsersDetailsQuery(string aspNetUsersId, int aspNetUserClaimsId)
        {
            this.AspNetUsersId = aspNetUsersId;
            this.AspNetUserClaimsId = aspNetUserClaimsId;
        }

        public class GetAspNetUserClaimsForAspNetUsersDetailsHandler : IRequestHandler<GetAspNetUserClaimsForAspNetUsersDetailsQuery, Response<GetAspNetUserClaimsForAspNetUsersResponseDto>>
        {
            private readonly ILogger<GetAspNetUserClaimsForAspNetUsersDetailsHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetAspNetUserClaimsForAspNetUsersDetailsHandler(ILogger<GetAspNetUserClaimsForAspNetUsersDetailsHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetAspNetUserClaimsForAspNetUsersResponseDto>> Handle(GetAspNetUserClaimsForAspNetUsersDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUserClaimsForAspNetUsersDetailsAsync(request.AspNetUsersId, request.AspNetUserClaimsId);
                return returnValue.ToResponse();
            }
        }
    }
}