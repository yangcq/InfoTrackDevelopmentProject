using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.Commands;

namespace WebScrape.Service.Abstraction
{
    public interface IRankValueRetrieve
    {
        public Task<int> Get(AddSearchCommand command);
    }
}
