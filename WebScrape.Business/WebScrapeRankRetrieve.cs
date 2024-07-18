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
        public async Task<int> Get(AddSearchCommand command)
        {
            return await SearchEngineFactory.GetSearchEngine(command.SearchEngine).
                GetRank(command.KeyWord, command.TargetURL);
        }
    }
}