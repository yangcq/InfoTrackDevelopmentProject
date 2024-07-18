using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.Library;
using System.Text.Json.Serialization;
using WebScrape.Service.Commands;
using WebScrape.Service.Queries;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace WebScrape.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : BaseController
    {
        public SearchController(IMediator mediator) : base(mediator) { }

        [HttpGet("Usage")]
        public async Task<IActionResult> Get()
        {
            return await Send(new GetUsagesQuery()).Process(x => new JsonResult(x));
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddSearchCommand addSearchCommand)
        {
            return await Send(addSearchCommand).Process(x => new JsonResult(x));
        }
    }
}
