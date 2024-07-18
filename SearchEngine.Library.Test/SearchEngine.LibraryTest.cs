using System.Text;

namespace SearchEngine.Library.Test
{
    public class RegexDataProcessTest
    {
        StringBuilder sb = new StringBuilder();

        [SetUp]
        public void Setup()
        {
            sb.AppendLine("<a>test123</a>");
            sb.AppendLine("<a>test222</a>");
            sb.AppendLine("<a>test345</a>");
            sb.AppendLine("<a>test422</a>");
            sb.AppendLine("<a>test524</a>");
            sb.AppendLine("<a>test622</a>");
            sb.AppendLine("<a>test732</a>");
            sb.AppendLine("<a>test234</a>");
            sb.AppendLine("<a>test324</a>");
        }

        [Test]
        public void Test1()
        {
            IRankParse process = new RegexRankParse("<a>(.+?)</a>");

            //not found
            Assert.That(process.GetResult(sb.ToString(), "test5024"), Is.EqualTo(-1));

            Assert.That(process.GetResult(sb.ToString(), "test524"), Is.EqualTo(4));
        }

        [Test]
        public void Test2()
        {
            IDataSource hTTPDataSource = new HTTPDataSource();
            Assert.IsNotEmpty(hTTPDataSource.GetData(@"https://www.infotrack.co.uk/").Result);
        }

        [Test]
        public void Test3()
        {
            ISearchEngine searchEngine = SearchEngineFactory.GetSearchEngine(SearchEngineType.Google);
            Assert.That(searchEngine.GetRank("land registry search", "www.gov.uk").Result, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Test4()
        {
            ISearchEngine searchEngine = SearchEngineFactory.GetSearchEngine(SearchEngineType.Yahoo);
            Assert.That(searchEngine.GetRank("land registry search", "landregistry.uk").Result, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Test5()
        {
            ISearchEngine searchEngine = SearchEngineFactory.GetSearchEngine(SearchEngineType.Bing);
            Assert.That(searchEngine.GetRank("land registry search", "www.gov.uk").Result, Is.GreaterThanOrEqualTo(0));
        }
    }
}