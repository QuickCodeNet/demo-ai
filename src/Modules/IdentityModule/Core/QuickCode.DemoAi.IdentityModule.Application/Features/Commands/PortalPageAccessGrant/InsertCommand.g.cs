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
    public class InsertPortalPageAccessGrantCommand : IRequest<Response<PortalPageAccessGrantDto>>
    {
        public PortalPageAccessGrantDto request { get; set; }

        public InsertPortalPageAccessGrantCommand(PortalPageAccessGrantDto request)
        {
            this.request = request;
        }

        public class InsertPortalPageAccessGrantHandler : IRequestHandler<InsertPortalPageAccessGrantCommand, Response<PortalPageAccessGrantDto>>
        {
            private readonly ILogger<InsertPortalPageAccessGrantHandler> _logger;
            private readonly IPortalPageAccessGrantRepository _repository;
            public InsertPortalPageAccessGrantHandler(ILogger<InsertPortalPageAccessGrantHandler> logger, IPortalPageAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<PortalPageAccessGrantDto>> Handle(InsertPortalPageAccessGrantCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}