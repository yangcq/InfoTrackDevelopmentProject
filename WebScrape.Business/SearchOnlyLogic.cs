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
    public class SearchOnlyLogic : IWebScrapeSearchLogic
    {
        public Task<SearchResult> Execute(AddSearchCommand request, CancellationToken cancellationToken)
        {
            //TODO: for standard applications where database is not required
            throw new NotImplementedException();
        }
    }
}
