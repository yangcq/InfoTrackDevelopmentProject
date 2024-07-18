using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrape.Service.Pipeline
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var stopWatcch = new Stopwatch();
            stopWatcch.Start();

            _logger.LogInformation($"Handling {typeof(TRequest).Name}");

            var response = await next();

            stopWatcch.Stop();

            _logger.LogInformation($"Handled {typeof(TResponse).Name} in {stopWatcch.Elapsed}");

            return response;
        }
    }
}
