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
    public class ListPortalMenuQuery : IRequest<Response<List<PortalMenuDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public ListPortalMenuQuery(int? pageNumber, int? pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        public class ListPortalMenuHandler : IRequestHandler<ListPortalMenuQuery, Response<List<PortalMenuDto>>>
        {
            private readonly ILogger<ListPortalMenuHandler> _logger;
            private readonly IPortalMenuRepository _repository;
            public ListPortalMenuHandler(ILogger<ListPortalMenuHandler> logger, IPortalMenuRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<PortalMenuDto>>> Handle(ListPortalMenuQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ListAsync(request.PageNumber, request.PageSize);
                return returnValue.ToResponse();
            }
        }
    }
}