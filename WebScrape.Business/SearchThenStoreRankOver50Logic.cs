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
    public class SearchThenStoreRankOver50Logic : IWebScrapeSearchLogic
    {
        public Task<RankDBResult> Execute(SearchEngineType SearchEngine, string KeyWord, string TargetURL, CancellationToken cancellationToken)
        {
            //TODO: only note down rank value over 50?
            throw new NotImplementedException();
        }
    }
}
