using System;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoAi.Portal.Models;
using QuickCode.DemoAi.Portal.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using QuickCode.DemoAi.Portal.Helpers.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using QuickCode.DemoAi.Common.Helpers;
using QuickCode.DemoAi.Common.Nswag.Clients.IdentityModuleApi.Contracts;

namespace QuickCode.DemoAi.Portal.Controllers.IdentityModule
{
    [Permission("IdentityModulePortalPageDefinitions")]
    public partial class KafkaEventsController : BaseController
    {
        [Route("GetKafkaEvents")]
        [HttpGet]
        public async Task<IActionResult> GetKafkaEvents()
        {
            var model = GetModel<GetKafkaEventsData>();
            var kafkaEvents = await pageClient.KafkaEventsGetKafkaEventsAsync();
            model.Items = new Dictionary<string, Dictionary<string, List<GetKafkaEventsResponseDto>>>();
            foreach (var item in kafkaEvents)
            {
                if(item.ControllerName.Contains("AuditLogsController"))
                {
                    continue;
                }
                
                var moduleName = item.UrlPath.Split('/')[2].KebabCaseToPascal("");
                if (item.ControllerName.Equals("AuthenticationsController"))
                {
                    moduleName = "IdentityModule";
                }
                model.Items.TryAdd(moduleName, new Dictionary<string, List<GetKafkaEventsResponseDto>>());
                model.Items[moduleName].TryAdd(item.ControllerName, []);
                model.Items[moduleName][item.ControllerName].Add(item);
            }

            SetModelBinder(ref model);
            return View("KafkaEvents", model);
        }

        [Route("UpdateKafkaEvent")]
        [HttpPost]
        public async Task<JsonResult> UpdateKafkaEvent(UpdateKafkaEvent request)
        {
            var eventData = await pageClient.KafkaEventsGetItemAsync(request.TopicName);
            eventData.IsActive = request.Value == 1;
            
            var result = await pageClient.KafkaEventsUpdateAsync(request.TopicName, eventData);
            return Json(result);
        }
    }
}

