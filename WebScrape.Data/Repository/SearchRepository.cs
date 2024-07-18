using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Data.Model;

namespace WebScrape.Data.Repository
{
    public class SearchRepository : IRepository<Search>
    {
        private readonly WebScrapeDB webScrapeDB;
        public SearchRepository(WebScrapeDB webScrapeDB)
        {
            this.webScrapeDB = webScrapeDB;
        }
        public async Task<IEnumerable<Search>> Get(CancellationToken cancellationToken = default)
        {
            return await webScrapeDB.Searches.ToListAsync(cancellationToken);
        }

        public async Task<Search> Get(Search item, CancellationToken cancellationToken = default)
        {
            if (item == null)
                return null;

            item.HashValue = item.GetHashCode();
            var list = await Get(cancellationToken);
            return list.Where(s => s.HashValue == item.HashValue).FirstOrDefault();
        }

        public async Task<Search> GetByID(int Id, CancellationToken cancellationToken = default)
        {
            return await webScrapeDB.Searches.Where(s => s.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task Insert(Search search, CancellationToken cancellationToken = default)
        {
            await webScrapeDB.Searches.AddAsync(search, cancellationToken);
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            await webScrapeDB.SaveChangesAsync(cancellationToken);
        }
    }
}
