using MediatR;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Queries
{
    public record GetRankingByIdQuery(int SearchID) : IRequest<RankingResult>;
}
