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
    public class GetItemKafkaEventQuery : IRequest<Response<KafkaEventDto>>
    {
        public string TopicName { get; set; }

        public GetItemKafkaEventQuery(string topicName)
        {
            this.TopicName = topicName;
        }

        public class GetItemKafkaEventHandler : IRequestHandler<GetItemKafkaEventQuery, Response<KafkaEventDto>>
        {
            private readonly ILogger<GetItemKafkaEventHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public GetItemKafkaEventHandler(ILogger<GetItemKafkaEventHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<KafkaEventDto>> Handle(GetItemKafkaEventQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.TopicName);
                return returnValue.ToResponse();
            }
        }
    }
}