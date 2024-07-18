using MediatR;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Queries
{
    public record GetRankByIdQuery(int SearchID) : IRequest<RankListResult>;
}
