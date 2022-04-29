using DemandManagement.Api.Models;
using DemandManagement.MessageContracts;
using Microsoft.AspNetCore.Mvc;

namespace DemandManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterDemandModel registerDemandModel)
        {
            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = new Uri($"{RabbitMqConstants.Uri}{RabbitMqConstants.RegisterDemandServiceQueueName}");
            var endPoint = bus.GetSendEndpoint(sendToUri).Result;

            await endPoint.Send<IRegisterDemandCommand>(registerDemandModel);

            return Ok();
        }
    }
}