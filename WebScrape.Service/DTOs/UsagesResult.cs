using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Library;

namespace WebScrape.Service.DTOs
{
    public class UsagesResult : BaseResult
    {
        public IDictionary<SearchEngineType, int> Usages { get; set; }
    }
}
