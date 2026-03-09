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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.PermissionGroup;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.PermissionGroup
{
    public class TotalCountPermissionGroupQuery : IRequest<Response<int>>
    {
        public TotalCountPermissionGroupQuery()
        {
        }

        public class TotalCountPermissionGroupHandler : IRequestHandler<TotalCountPermissionGroupQuery, Response<int>>
        {
            private readonly ILogger<TotalCountPermissionGroupHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public TotalCountPermissionGroupHandler(ILogger<TotalCountPermissionGroupHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountPermissionGroupQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}