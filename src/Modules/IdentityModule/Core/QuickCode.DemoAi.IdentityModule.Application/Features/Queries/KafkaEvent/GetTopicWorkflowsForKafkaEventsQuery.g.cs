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
    public class GetTopicWorkflowsForKafkaEventsQuery : IRequest<Response<List<GetTopicWorkflowsForKafkaEventsResponseDto>>>
    {
        public string KafkaEventsTopicName { get; set; }

        public GetTopicWorkflowsForKafkaEventsQuery(string kafkaEventsTopicName)
        {
            this.KafkaEventsTopicName = kafkaEventsTopicName;
        }

        public class GetTopicWorkflowsForKafkaEventsHandler : IRequestHandler<GetTopicWorkflowsForKafkaEventsQuery, Response<List<GetTopicWorkflowsForKafkaEventsResponseDto>>>
        {
            private readonly ILogger<GetTopicWorkflowsForKafkaEventsHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public GetTopicWorkflowsForKafkaEventsHandler(ILogger<GetTopicWorkflowsForKafkaEventsHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetTopicWorkflowsForKafkaEventsResponseDto>>> Handle(GetTopicWorkflowsForKafkaEventsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetTopicWorkflowsForKafkaEventsAsync(request.KafkaEventsTopicName);
                return returnValue.ToResponse();
            }
        }
    }
}