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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.AspNetUserLogin;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.AspNetUserLogin
{
    public class GetItemAspNetUserLoginQuery : IRequest<Response<AspNetUserLoginDto>>
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }

        public GetItemAspNetUserLoginQuery(string loginProvider, string providerKey)
        {
            this.LoginProvider = loginProvider;
            this.ProviderKey = providerKey;
        }

        public class GetItemAspNetUserLoginHandler : IRequestHandler<GetItemAspNetUserLoginQuery, Response<AspNetUserLoginDto>>
        {
            private readonly ILogger<GetItemAspNetUserLoginHandler> _logger;
            private readonly IAspNetUserLoginRepository _repository;
            public GetItemAspNetUserLoginHandler(ILogger<GetItemAspNetUserLoginHandler> logger, IAspNetUserLoginRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserLoginDto>> Handle(GetItemAspNetUserLoginQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.LoginProvider, request.ProviderKey);
                return returnValue.ToResponse();
            }
        }
    }
}