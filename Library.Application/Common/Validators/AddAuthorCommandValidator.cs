using FluentValidation;
using Library.Application.Author.Commands;

namespace Library.Application.Common.Validators
{
    public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
    {
        public AddAuthorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).Length(3, 50);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).MinimumLength(3);
            RuleFor(x => x.FirstName).MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).MinimumLength(3);
            RuleFor(x => x.LastName).MaximumLength(100);
        }
    }
}