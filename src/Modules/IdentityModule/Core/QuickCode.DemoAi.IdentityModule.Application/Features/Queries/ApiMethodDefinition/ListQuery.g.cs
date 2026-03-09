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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.ApiMethodDefinition;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.ApiMethodDefinition
{
    public class ListApiMethodDefinitionQuery : IRequest<Response<List<ApiMethodDefinitionDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public ListApiMethodDefinitionQuery(int? pageNumber, int? pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        public class ListApiMethodDefinitionHandler : IRequestHandler<ListApiMethodDefinitionQuery, Response<List<ApiMethodDefinitionDto>>>
        {
            private readonly ILogger<ListApiMethodDefinitionHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public ListApiMethodDefinitionHandler(ILogger<ListApiMethodDefinitionHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<ApiMethodDefinitionDto>>> Handle(ListApiMethodDefinitionQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ListAsync(request.PageNumber, request.PageSize);
                return returnValue.ToResponse();
            }
        }
    }
}