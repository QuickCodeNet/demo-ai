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
    public class UpdateRefreshTokensCommand : IRequest<Response<int>>
    {
        public string RefreshTokenToken { get; set; }
        public UpdateRefreshTokensRequestDto UpdateRequest { get; set; }

        public UpdateRefreshTokensCommand(string refreshTokenToken, UpdateRefreshTokensRequestDto updateRequest)
        {
            this.RefreshTokenToken = refreshTokenToken;
            this.UpdateRequest = updateRequest;
        }

        public class UpdateRefreshTokensHandler : IRequestHandler<UpdateRefreshTokensCommand, Response<int>>
        {
            private readonly ILogger<UpdateRefreshTokensHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public UpdateRefreshTokensHandler(ILogger<UpdateRefreshTokensHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(UpdateRefreshTokensCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.UpdateRefreshTokensAsync(request.RefreshTokenToken, request.UpdateRequest);
                return returnValue.ToResponse();
            }
        }
    }
}