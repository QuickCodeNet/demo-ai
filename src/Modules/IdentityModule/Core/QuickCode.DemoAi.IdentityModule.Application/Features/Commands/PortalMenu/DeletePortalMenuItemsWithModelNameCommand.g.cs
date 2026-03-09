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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.PortalMenu;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.PortalMenu
{
    public class DeletePortalMenuItemsWithModelNameCommand : IRequest<Response<int>>
    {
        public string PortalMenuKey { get; set; }
        public string PortalMenuName { get; set; }

        public DeletePortalMenuItemsWithModelNameCommand(string portalMenuKey, string portalMenuName)
        {
            this.PortalMenuKey = portalMenuKey;
            this.PortalMenuName = portalMenuName;
        }

        public class DeletePortalMenuItemsWithModelNameHandler : IRequestHandler<DeletePortalMenuItemsWithModelNameCommand, Response<int>>
        {
            private readonly ILogger<DeletePortalMenuItemsWithModelNameHandler> _logger;
            private readonly IPortalMenuRepository _repository;
            public DeletePortalMenuItemsWithModelNameHandler(ILogger<DeletePortalMenuItemsWithModelNameHandler> logger, IPortalMenuRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(DeletePortalMenuItemsWithModelNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.DeletePortalMenuItemsWithModelNameAsync(request.PortalMenuKey, request.PortalMenuName);
                return returnValue.ToResponse();
            }
        }
    }
}