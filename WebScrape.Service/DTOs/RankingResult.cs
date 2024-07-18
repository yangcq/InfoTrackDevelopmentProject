using System.ComponentModel;

namespace WebScrape.Service.DTOs
{
    public class RankingResult : BaseResult
    {
        public List<KeyValuePair<string, int>>? Rankings { get; set; }
    }
}
