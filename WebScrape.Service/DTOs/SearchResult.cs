using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrape.Service.DTOs
{
    public class SearchResult : BaseResult
    {
        public int Ranking { get; set; }
        public int Count { get; set; }
    }
}
