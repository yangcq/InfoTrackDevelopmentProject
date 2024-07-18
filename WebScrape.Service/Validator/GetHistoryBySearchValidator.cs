using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrape.Service.Queries;

namespace WebScrape.Service.Validator
{
    public class GetHistoryBySearchValidator : AbstractValidator<GetRankingBySearchQuery>
    {
        public GetHistoryBySearchValidator()
        {
            RuleFor(s => s.KeyWord).NotEmpty().WithMessage("KeyWord is empty");
            RuleFor(s => s.TargetURL).NotEmpty().WithMessage("TargetURL is empty");
            RuleFor(s => s.SearchEngine).IsInEnum().WithMessage("SearchEngine is wrong");
        }
    }
}
