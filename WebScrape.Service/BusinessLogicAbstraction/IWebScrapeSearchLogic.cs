using MediatR;
using SearchEngine.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.Commands;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Abstraction
{
    public interface IWebScrapeSearchLogic
    {
        public Task<RankDBResult> Execute(SearchEngineType SearchEngine, string KeyWord, string TargetURL, CancellationToken cancellationToken);
    }
}
