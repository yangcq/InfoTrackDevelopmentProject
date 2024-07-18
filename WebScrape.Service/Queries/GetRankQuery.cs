using MediatR;
using SearchEngine.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Queries
{
    public record GetRankQuery(SearchEngineType SearchEngine, string KeyWord, string TargetURL) : IRequest<RankResult>;
}
