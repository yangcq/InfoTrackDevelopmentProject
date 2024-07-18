using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SearchEngine.Library
{
    public class HTTPDataSource : IDataSource
    {
        public async Task<string> GetData(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return HttpUtility.HtmlDecode(await client.GetStringAsync(url));
            }
        }
    }
}
