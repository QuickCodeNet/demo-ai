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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.AspNetUser;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.AspNetUser
{
    public class GetItemAspNetUserQuery : IRequest<Response<AspNetUserDto>>
    {
        public string Id { get; set; }

        public GetItemAspNetUserQuery(string id)
        {
            this.Id = id;
        }

        public class GetItemAspNetUserHandler : IRequestHandler<GetItemAspNetUserQuery, Response<AspNetUserDto>>
        {
            private readonly ILogger<GetItemAspNetUserHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetItemAspNetUserHandler(ILogger<GetItemAspNetUserHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserDto>> Handle(GetItemAspNetUserQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}