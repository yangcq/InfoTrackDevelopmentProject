using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchEngine.Library
{
    public class RegexRankParse : IRankParse
    {
        private string pattern;
        public RegexRankParse(string pattern)
        {
            this.pattern = pattern;
        }

        public int GetResult(string content, string targetURL)
        {
            var matches = Regex.Matches(content, $"{pattern}");
            return matches.Select(x => x.Value).ToList().FindIndex(x => x.ToLower().Contains(targetURL.ToLower()));
        }
    }
}
