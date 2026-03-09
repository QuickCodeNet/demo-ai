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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.TableComboboxSetting;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.TableComboboxSetting
{
    public class GetItemTableComboboxSettingQuery : IRequest<Response<TableComboboxSettingDto>>
    {
        public string TableName { get; set; }

        public GetItemTableComboboxSettingQuery(string tableName)
        {
            this.TableName = tableName;
        }

        public class GetItemTableComboboxSettingHandler : IRequestHandler<GetItemTableComboboxSettingQuery, Response<TableComboboxSettingDto>>
        {
            private readonly ILogger<GetItemTableComboboxSettingHandler> _logger;
            private readonly ITableComboboxSettingRepository _repository;
            public GetItemTableComboboxSettingHandler(ILogger<GetItemTableComboboxSettingHandler> logger, ITableComboboxSettingRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<TableComboboxSettingDto>> Handle(GetItemTableComboboxSettingQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.TableName);
                return returnValue.ToResponse();
            }
        }
    }
}