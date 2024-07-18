using System.ComponentModel;

namespace WebScrape.Service.DTOs
{
    public class RankListResult : BaseResult
    {
        public List<KeyValuePair<string, int>>? Rankings { get; set; }
    }
}
