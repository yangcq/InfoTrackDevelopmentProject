using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace SearchEngine.Library
{
    public class SearchEngine : ISearchEngine
    {
        protected string baseURL;
        private IDataSource IDataSource;
        private IRankParse IRankParse;

        public SearchEngine(
            string baseURL,
            IDataSource IDataSource,
            IRankParse IRankParse)
        {
            this.baseURL = baseURL;
            this.IDataSource = IDataSource;
            this.IRankParse = IRankParse;
        }

        public async Task<int> GetRank(string keyWord, string targetURL, int searchLimit = 100)
        {
            if (string.IsNullOrWhiteSpace(keyWord))
                throw new Exception("keyWord is empty");

            string requestURL = string.Format(baseURL, searchLimit, HttpUtility.UrlEncode(keyWord.Trim()));

            string result = await IDataSource.GetData(requestURL);
            return IRankParse.GetResult(result, targetURL);
        }
    }
}
