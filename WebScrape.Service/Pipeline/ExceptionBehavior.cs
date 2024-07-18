using MediatR;
using Microsoft.Extensions.Logging;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Pipeline
{
    public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : BaseResult, new()
    {
        private readonly ILogger _logger;
        public ExceptionBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to process request of type {typeof(TRequest).Name}", request);
                return new TResponse()
                {
                    Errors = new List<string>(1) { e.Message }
                };
            }
        }
    }
}
