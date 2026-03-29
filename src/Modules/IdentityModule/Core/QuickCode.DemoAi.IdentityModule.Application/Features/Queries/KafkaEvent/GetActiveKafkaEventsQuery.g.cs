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
using QuickCode.DemoAi.IdentityModule.Application.Dtos.KafkaEvent;
using QuickCode.DemoAi.IdentityModule.Domain.Enums;

namespace QuickCode.DemoAi.IdentityModule.Application.Features.KafkaEvent
{
    public class GetActiveKafkaEventsQuery : IRequest<Response<List<GetActiveKafkaEventsResponseDto>>>
    {
        public bool KafkaEventIsActive { get; set; }

        public GetActiveKafkaEventsQuery(bool kafkaEventIsActive)
        {
            this.KafkaEventIsActive = kafkaEventIsActive;
        }

        public class GetActiveKafkaEventsHandler : IRequestHandler<GetActiveKafkaEventsQuery, Response<List<GetActiveKafkaEventsResponseDto>>>
        {
            private readonly ILogger<GetActiveKafkaEventsHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public GetActiveKafkaEventsHandler(ILogger<GetActiveKafkaEventsHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetActiveKafkaEventsResponseDto>>> Handle(GetActiveKafkaEventsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetActiveKafkaEventsAsync(request.KafkaEventIsActive);
                return returnValue.ToResponse();
            }
        }
    }
}