﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Data.Model;
using WebScrape.Service.DTOs;
using WebScrape.Service.Queries;
using WebScrape.Data.Repository;

namespace WebScrape.Service.Handlers
{
    public class GetRankBySearchIdHandler : IRequestHandler<GetRankByIdQuery, RankListResult>
    {
        private readonly IRepository<Search> repository;
        public GetRankBySearchIdHandler(IRepository<Search> repository)
        {
            this.repository = repository;
        }

        public async Task<RankListResult> Handle(GetRankByIdQuery request, CancellationToken cancellationToken)
        {
            var list = await repository.GetByID(request.SearchID, cancellationToken);
            if (list == null)
                return new RankListResult();
            return new RankListResult()
            {
                Rankings = list.Rankings
                .Select(x => new { V = x.Created.ToString("yyyy-MM-dd HH:mm"), x.Rank })
                .Select(x => new KeyValuePair<string, int>(x.V, x.Rank)).ToList()
            };
        }
    }
}
