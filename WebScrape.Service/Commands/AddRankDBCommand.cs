using MediatR;
using SearchEngine.Library;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Commands
{
    public record AddRankDBCommand(SearchEngineType SearchEngine, string KeyWord, string TargetURL) : IRequest<RankDBResult>;
}
