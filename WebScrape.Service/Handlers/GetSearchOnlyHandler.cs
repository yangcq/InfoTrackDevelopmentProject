using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.Abstraction;
using WebScrape.Service.Commands;
using WebScrape.Service.DTOs;
using WebScrape.Service.Queries;

namespace WebScrape.Service.Handlers
{
    internal class GetSearchOnlyHandler : IRequestHandler<GetRankQuery, RankResult>
    {
        private readonly IRankValueRetrieve rankValueRetrieve;

        public GetSearchOnlyHandler(IRankValueRetrieve rankValueRetrieve)
        {
            this.rankValueRetrieve = rankValueRetrieve;
        }

        public async Task<RankResult> Handle(GetRankQuery request, CancellationToken cancellationToken)
        {
            int result = await rankValueRetrieve.Get(request.SearchEngine, request.KeyWord, request.TargetURL, cancellationToken);
            return new RankResult() { Rank = result };
        }
    }
}
