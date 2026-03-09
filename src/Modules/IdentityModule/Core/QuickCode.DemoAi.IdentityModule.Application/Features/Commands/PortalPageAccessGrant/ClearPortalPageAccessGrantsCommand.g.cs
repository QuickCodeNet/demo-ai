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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.PortalPageAccessGrant;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.PortalPageAccessGrant
{
    public class ClearPortalPageAccessGrantsCommand : IRequest<Response<int>>
    {
        public ClearPortalPageAccessGrantsCommand()
        {
        }

        public class ClearPortalPageAccessGrantsHandler : IRequestHandler<ClearPortalPageAccessGrantsCommand, Response<int>>
        {
            private readonly ILogger<ClearPortalPageAccessGrantsHandler> _logger;
            private readonly IPortalPageAccessGrantRepository _repository;
            public ClearPortalPageAccessGrantsHandler(ILogger<ClearPortalPageAccessGrantsHandler> logger, IPortalPageAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(ClearPortalPageAccessGrantsCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ClearPortalPageAccessGrantsAsync();
                return returnValue.ToResponse();
            }
        }
    }
}