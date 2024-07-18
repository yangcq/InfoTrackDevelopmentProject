using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Data.Model;

namespace WebScrape.Data.Repository
{
    public class RankingRepository : IRepository<Ranking>
    {
        private readonly WebScrapeDB webScrapeDB;
        public RankingRepository(WebScrapeDB webScrapeDB)
        {
            this.webScrapeDB = webScrapeDB;
        }

        public async Task<Ranking> GetByID(int Id, CancellationToken cancellationToken = default)
        {
            return await webScrapeDB.Rankings.Where(s => s.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Ranking>> Get(CancellationToken cancellationToken = default)
        {
            return await webScrapeDB.Rankings.ToListAsync(cancellationToken);
        }

        public async Task Insert(Ranking Ranking, CancellationToken cancellationToken = default)
        {
            await webScrapeDB.Rankings.AddAsync(Ranking, cancellationToken);
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            await webScrapeDB.SaveChangesAsync(cancellationToken);
        }

        public async Task<Ranking> Get(Ranking item, CancellationToken cancellationToken = default)
        {
            var list = await Get(cancellationToken);
            return list.Where(x => x.Rank == item.Rank && x.SearchId == item.SearchId && x.Created == item.Created).FirstOrDefault();
        }
    }
}
