using MediatR;
using SearchEngine.Library;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Commands
{
    public record AddRankCommand(SearchEngineType SearchEngine, string KeyWord, string TargetURL) : IRequest<RankDBResult>;
}
