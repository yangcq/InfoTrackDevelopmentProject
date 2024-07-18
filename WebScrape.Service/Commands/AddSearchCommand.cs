using MediatR;
using SearchEngine.Library;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Commands
{
    public record AddSearchCommand(SearchEngineType SearchEngine, string KeyWord, string TargetURL) : IRequest<SearchResult>;
}
