using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.Library;
using WebScrape.Service.Commands;
using WebScrape.Service.Queries;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace WebScrape.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RankController : BaseController
    {
        public RankController(IMediator mediator) : base(mediator) { }

        [HttpGet("ID")]
        public async Task<IActionResult> GetById(int searchId)
        {
            return await Send(new GetRankByIdQuery(searchId)).Process(x => new JsonResult(x));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetRankBySearchQuery addSearchCommand)
        {
            return await Send(addSearchCommand).Process(x => new JsonResult(x));
        }
    }
}
