using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Library
{
    public interface IRankParse
    {
        public int GetResult(string content, string targetURL);
    }
}
