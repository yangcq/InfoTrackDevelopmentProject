using SearchEngine.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.Commands;

namespace WebScrape.Service.Abstraction
{
    public interface IRankValueRetrieve
    {
        public Task<int> Get(SearchEngineType SearchEngine, string KeyWord, string TargetURL, CancellationToken cancellationToken);
    }
}
