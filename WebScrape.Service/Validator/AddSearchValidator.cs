using FluentValidation;
using WebScrape.Service.Commands;

namespace WebScrape.Service.Validator
{
    public class AddSearchValidator : AbstractValidator<AddSearchCommand>
    {
        public AddSearchValidator()
        {
            RuleFor(s => s.KeyWord).NotEmpty().WithMessage("KeyWord is empty");
            RuleFor(s => s.TargetURL).NotEmpty().WithMessage("TargetURL is empty");
            RuleFor(s => s.SearchEngine).IsInEnum().WithMessage("SearchEngine is wrong");
        }
    }
}
