using MediatR;
using SearchEngine.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.Abstraction;
using WebScrape.Service.Commands;
using WebScrape.Service.DTOs;

namespace WebScrape.Business
{
    public class SearchThenStoreRankBasedonTimestampLogic : IWebScrapeSearchLogic
    {
        public Task<RankDBResult> Execute(SearchEngineType SearchEngine, string KeyWord, string TargetURL, CancellationToken cancellationToken)
        {
            // TODO: Only save if a certain amount of time has passed since the last result
            throw new NotImplementedException();
        }
    }
}
