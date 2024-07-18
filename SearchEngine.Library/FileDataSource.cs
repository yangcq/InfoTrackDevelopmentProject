using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Library
{
    public class FileDataSource : IDataSource
    {
        public async Task<string> GetData(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new Exception("url is empty");

            if (File.Exists(url))
                await File.ReadAllTextAsync(url);

            throw new Exception("file does not exist");
        }
    }
}