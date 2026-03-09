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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.RefreshToken;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.RefreshToken
{
    public class InsertRefreshTokenCommand : IRequest<Response<RefreshTokenDto>>
    {
        public RefreshTokenDto request { get; set; }

        public InsertRefreshTokenCommand(RefreshTokenDto request)
        {
            this.request = request;
        }

        public class InsertRefreshTokenHandler : IRequestHandler<InsertRefreshTokenCommand, Response<RefreshTokenDto>>
        {
            private readonly ILogger<InsertRefreshTokenHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public InsertRefreshTokenHandler(ILogger<InsertRefreshTokenHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<RefreshTokenDto>> Handle(InsertRefreshTokenCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}