using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebScrape.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<TResponse> Send<TResponse>(IRequest<TResponse> query)
        {
            return await _mediator.Send(query);
        }
    }
}
