using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Library
{
    public interface ISearchEngine
    {
        public Task<int> GetRank(string keyWord, string targetURL, int searchLimit = 100);
    }
}
