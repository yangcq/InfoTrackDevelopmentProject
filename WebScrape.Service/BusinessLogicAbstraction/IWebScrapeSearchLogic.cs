﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.Commands;
using WebScrape.Service.DTOs;

namespace WebScrape.Service.Abstraction
{
    public interface IWebScrapeSearchLogic
    {
        public Task<SearchResult> Execute(AddSearchCommand request, CancellationToken cancellationToken);
    }
}
