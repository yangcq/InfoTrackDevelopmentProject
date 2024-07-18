using Azure.Core;
using SearchEngine.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.Abstraction;
using WebScrape.Service.Commands;

namespace WebScrape.Business
{
    public class WebScrapeRankRetrieve : IRankValueRetrieve
    {
        public async Task<int> Get(SearchEngineType SearchEngine, string KeyWord, string TargetURL, CancellationToken cancellationToken)
        {
            return await SearchEngineFactory.GetSearchEngine(SearchEngine).GetRank(KeyWord, TargetURL);
        }
    }
}