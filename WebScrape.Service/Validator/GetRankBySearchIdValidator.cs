using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.Queries;

namespace WebScrape.Service.Validator
{
    public class GetRankBySearchIdValidator : AbstractValidator<GetRankByIdQuery>
    {
        public GetRankBySearchIdValidator()
        {
            RuleFor(x => x.SearchID).NotEmpty().WithMessage("SearchID is empty");
            RuleFor(x => x.SearchID).GreaterThan(0).WithMessage("SearchID is wrong");
        }
    }
}
