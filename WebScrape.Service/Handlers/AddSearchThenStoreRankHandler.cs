using MediatR;
using SearchEngine.Library;
using WebScrape.Data.Model;
using WebScrape.Service.Commands;
using WebScrape.Service.DTOs;
using WebScrape.Data.Repository;
using WebScrape.Service.Abstraction;

namespace WebScrape.Service.Handlers
{
    public class AddSearchThenStoreRankHandler : IRequestHandler<AddRankDBCommand, RankDBResult>
    {
        private readonly IWebScrapeSearchLogic webScrapeSearchLogic;

        public AddSearchThenStoreRankHandler(IWebScrapeSearchLogic webScrapeSearchLogic)
        {
            this.webScrapeSearchLogic = webScrapeSearchLogic;
        }

        public async Task<RankDBResult> Handle(AddRankDBCommand request, CancellationToken cancellationToken)
        {
            return await webScrapeSearchLogic.Execute(request.SearchEngine, request.KeyWord, request.TargetURL, cancellationToken);
        }
    }
}
