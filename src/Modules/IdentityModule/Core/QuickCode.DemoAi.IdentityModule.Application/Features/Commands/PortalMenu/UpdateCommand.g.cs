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
    public class UpdatePortalMenuCommand : IRequest<Response<bool>>
    {
        public string Key { get; set; }
        public PortalMenuDto request { get; set; }

        public UpdatePortalMenuCommand(string key, PortalMenuDto request)
        {
            this.request = request;
            this.Key = key;
        }

        public class UpdatePortalMenuHandler : IRequestHandler<UpdatePortalMenuCommand, Response<bool>>
        {
            private readonly ILogger<UpdatePortalMenuHandler> _logger;
            private readonly IPortalMenuRepository _repository;
            public UpdatePortalMenuHandler(ILogger<UpdatePortalMenuHandler> logger, IPortalMenuRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdatePortalMenuCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Key);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}