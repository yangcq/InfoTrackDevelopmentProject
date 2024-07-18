using MediatR;
using SearchEngine.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScrape.Data.Model;
using WebScrape.Data.Repository;
using WebScrape.Service.Abstraction;
using WebScrape.Service.Commands;
using WebScrape.Service.DTOs;

namespace WebScrape.Business
{
    public class SearchThenStoreRankLogic : IWebScrapeSearchLogic
    {
        private readonly IRepository<Search> searchRepository;
        private readonly IRepository<Ranking> rankingRepository;
        private readonly IRankValueRetrieve rankValueRetrieve;

        public SearchThenStoreRankLogic(
            IRepository<Search> searchRepository,
            IRepository<Ranking> rankingRepository,
            IRankValueRetrieve rankValueRetrieve)
        {
            this.searchRepository = searchRepository;
            this.rankingRepository = rankingRepository;
            this.rankValueRetrieve = rankValueRetrieve;
        }

        public async Task<SearchResult> Execute(AddSearchCommand request, CancellationToken cancellationToken)
        {
            int rankResult = await rankValueRetrieve.Get(request);
            Search newItem = new()
            {
                SearchEngine = request.SearchEngine,
                KeyWord = request.KeyWord,
                TargetURL = request.TargetURL
            };
            // check if the same search exists
            var existItem = await searchRepository.Get(newItem);

            // new search
            if (existItem == null)
                await searchRepository.Insert(newItem, cancellationToken);
            else
                existItem.SearchCount++;

            // a ranking result is found
            if (rankResult > -1)
            {
                await rankingRepository.Insert(new Ranking()
                {
                    Rank = rankResult + 1,
                    Created = DateTime.Now,
                    Search = existItem == null ? newItem : existItem
                }, cancellationToken);
                await rankingRepository.Save(cancellationToken);
            }

            await searchRepository.Save(cancellationToken);

            return new SearchResult
            {
                Ranking = rankResult == -1 ? rankResult : rankResult + 1,
                Count = existItem == null ? 1 : existItem.SearchCount
            };
        }
    }
}