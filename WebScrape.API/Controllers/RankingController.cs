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
    public class RankingController : BaseController
    {
        public RankingController(IMediator mediator) : base(mediator) { }

        [HttpGet("ID")]
        public async Task<IActionResult> GetById(int searchId)
        {
            return await Send(new GetRankingByIdQuery(searchId)).Process(x => new JsonResult(x));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetRankingBySearchQuery addSearchCommand)
        {
            return await Send(addSearchCommand).Process(x => new JsonResult(x));
        }
    }
}
