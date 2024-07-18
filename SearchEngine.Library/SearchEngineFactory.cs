namespace SearchEngine.Library
{
    public static class SearchEngineFactory
    {
        public static ISearchEngine GetSearchEngine(SearchEngineType SearchEngineType)
        {
            switch (SearchEngineType)
            {
                case SearchEngineType.Google:
                    return new SearchEngine(
                        "https://www.google.co.uk/search?num={0}&q={1}",
                        new HTTPDataSource(),
                        new RegexRankParse($"class=\"egMi0 kCrYT\">(.+?)sa=U&ved="));
                case SearchEngineType.Bing:
                    return new SearchEngine(
                        "https://www.bing.com/search?count={0}&q={1}",
                        new HTTPDataSource(),
                        new RegexRankParse($"<cite>(.+?)<cite>"));
                case SearchEngineType.Yahoo:
                    return new SearchEngine(
                        "https://uk.search.yahoo.com/search?n={0}&p={1}",
                        new HTTPDataSource(),
                        new RegexRankParse($"ad-domain fz-14 lh-20 s-url fc-obsidian d-ib pb-4\">(.+?)</span>"));
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
