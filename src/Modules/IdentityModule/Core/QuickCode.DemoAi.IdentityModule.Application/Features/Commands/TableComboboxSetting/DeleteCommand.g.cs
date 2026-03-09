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
    public class DeleteTableComboboxSettingCommand : IRequest<Response<bool>>
    {
        public TableComboboxSettingDto request { get; set; }

        public DeleteTableComboboxSettingCommand(TableComboboxSettingDto request)
        {
            this.request = request;
        }

        public class DeleteTableComboboxSettingHandler : IRequestHandler<DeleteTableComboboxSettingCommand, Response<bool>>
        {
            private readonly ILogger<DeleteTableComboboxSettingHandler> _logger;
            private readonly ITableComboboxSettingRepository _repository;
            public DeleteTableComboboxSettingHandler(ILogger<DeleteTableComboboxSettingHandler> logger, ITableComboboxSettingRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteTableComboboxSettingCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}