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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.ColumnType;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.ColumnType
{
    public class InsertColumnTypeCommand : IRequest<Response<ColumnTypeDto>>
    {
        public ColumnTypeDto request { get; set; }

        public InsertColumnTypeCommand(ColumnTypeDto request)
        {
            this.request = request;
        }

        public class InsertColumnTypeHandler : IRequestHandler<InsertColumnTypeCommand, Response<ColumnTypeDto>>
        {
            private readonly ILogger<InsertColumnTypeHandler> _logger;
            private readonly IColumnTypeRepository _repository;
            public InsertColumnTypeHandler(ILogger<InsertColumnTypeHandler> logger, IColumnTypeRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<ColumnTypeDto>> Handle(InsertColumnTypeCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}