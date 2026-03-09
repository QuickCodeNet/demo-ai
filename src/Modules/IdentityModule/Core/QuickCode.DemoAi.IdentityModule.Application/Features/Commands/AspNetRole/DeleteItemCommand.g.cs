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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.AspNetRole;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.AspNetRole
{
    public class DeleteItemAspNetRoleCommand : IRequest<Response<bool>>
    {
        public string Id { get; set; }

        public DeleteItemAspNetRoleCommand(string id)
        {
            this.Id = id;
        }

        public class DeleteItemAspNetRoleHandler : IRequestHandler<DeleteItemAspNetRoleCommand, Response<bool>>
        {
            private readonly ILogger<DeleteItemAspNetRoleHandler> _logger;
            private readonly IAspNetRoleRepository _repository;
            public DeleteItemAspNetRoleHandler(ILogger<DeleteItemAspNetRoleHandler> logger, IAspNetRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteItemAspNetRoleCommand request, CancellationToken cancellationToken)
            {
                var deleteItem = await _repository.GetByPkAsync(request.Id);
                if (deleteItem.Code == 404)
                    return Response<bool>.NotFound();
                var returnValue = await _repository.DeleteAsync(deleteItem.Value);
                return returnValue.ToResponse();
            }
        }
    }
}