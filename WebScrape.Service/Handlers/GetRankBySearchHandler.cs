using MediatR;
using WebScrape.Data.Model;
using WebScrape.Service.DTOs;
using WebScrape.Service.Queries;
using WebScrape.Data.Repository;

namespace WebScrape.Service.Handlers
{
    public class GetRankBySearchHandler : IRequestHandler<GetRankBySearchQuery, RankListResult>
    {
        private readonly IRepository<Search> repository;
        private readonly IMediator mediator;
        public GetRankBySearchHandler(IRepository<Search> repository, IMediator mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }
        public async Task<RankListResult> Handle(GetRankBySearchQuery request, CancellationToken cancellationToken)
        {
            Search newItem = new()
            {
                SearchEngine = request.SearchEngine,
                KeyWord = request.KeyWord,
                TargetURL = request.TargetURL
            };
            var list = await repository.Get(cancellationToken);
            var existItem = list.Where(s => s.HashValue == newItem.GetHashCode()).FirstOrDefault();
            if (existItem != null)
                return await mediator.Send(new GetRankByIdQuery(existItem.Id));
            return new RankListResult();
        }
    }
}
