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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.AspNetUserRole;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.AspNetUserRole
{
    public class DeleteAspNetUserRoleCommand : IRequest<Response<bool>>
    {
        public AspNetUserRoleDto request { get; set; }

        public DeleteAspNetUserRoleCommand(AspNetUserRoleDto request)
        {
            this.request = request;
        }

        public class DeleteAspNetUserRoleHandler : IRequestHandler<DeleteAspNetUserRoleCommand, Response<bool>>
        {
            private readonly ILogger<DeleteAspNetUserRoleHandler> _logger;
            private readonly IAspNetUserRoleRepository _repository;
            public DeleteAspNetUserRoleHandler(ILogger<DeleteAspNetUserRoleHandler> logger, IAspNetUserRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteAspNetUserRoleCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}