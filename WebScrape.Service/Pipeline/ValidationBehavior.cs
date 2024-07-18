using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Pipeline
{
    public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : BaseResult, new()
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<TRequest> _logger;

        public ValidationBehavior(IServiceProvider serviceProvider, ILogger<TRequest> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider.GetServices<IValidator<TRequest>>().ToList();

                if (services.Count <= 0)
                    return await next();

                foreach (var service in services)
                {
                    var result = await service.ValidateAsync(request, cancellationToken);
                    if (result.IsValid)
                        continue;

                    _logger.LogWarning($"Validation failed for type {typeof(TResponse).Name}", result.Errors);

                    return new TResponse
                    {
                        Errors = result.Errors.Select(x => x.ErrorMessage).ToList()
                    };
                }
            }
            return await next();
        }
    }
}
