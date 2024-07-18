using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Library;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Queries
{
    public record GetRankingBySearchQuery(SearchEngineType SearchEngine, string KeyWord, string TargetURL) : IRequest<RankingResult>;
}
