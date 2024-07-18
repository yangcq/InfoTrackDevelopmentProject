using MediatR;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Queries
{
    public record GetUsagesQuery : IRequest<UsagesResult>;
}