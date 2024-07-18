using MediatR;
using SearchEngine.Library;
using WebScrape.Data.Model;
using WebScrape.Service.Commands;
using WebScrape.Service.DTOs;
using WebScrape.Data.Repository;
using WebScrape.Service.Abstraction;

namespace WebScrape.Service.Handlers
{
    public class AddSearchHandler : IRequestHandler<AddSearchCommand, SearchResult>
    {
        private readonly IWebScrapeSearchLogic webScrapeSearchLogic;

        public AddSearchHandler(IWebScrapeSearchLogic webScrapeSearchLogic)
        {
            this.webScrapeSearchLogic = webScrapeSearchLogic;
        }

        public async Task<SearchResult> Handle(AddSearchCommand request, CancellationToken cancellationToken)
        {
            return await webScrapeSearchLogic.Execute(request, cancellationToken);
        }
    }
}
