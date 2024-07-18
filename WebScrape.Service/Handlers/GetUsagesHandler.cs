using MediatR;
using WebScrape.Data.Model;
using WebScrape.Service.DTOs;
using WebScrape.Service.Queries;
using WebScrape.Data.Repository;

namespace WebScrape.Service.Handlers
{
    public class GetUsagesHandler : IRequestHandler<GetUsagesQuery, UsagesResult>
    {
        private readonly IRepository<Search> searchRepository;

        public GetUsagesHandler(IRepository<Search> searchRepository)
        {
            this.searchRepository = searchRepository;
        }

        public async Task<UsagesResult> Handle(GetUsagesQuery request, CancellationToken cancellationToken)
        {
            var list = await searchRepository.Get(cancellationToken);
            return new UsagesResult()
            {
                Usages = list.GroupBy(s => s.SearchEngine)
                .Select(g => new { g.Key, Count = g.Sum(x => x.SearchCount) })
                .ToDictionary(g => g.Key, g => g.Count)
            };
        }
    }
}