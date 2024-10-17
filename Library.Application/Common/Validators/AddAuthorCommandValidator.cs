using FluentValidation;
using Library.Application.Author.Commands;

namespace Library.Application.Common.Validators
{
    public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
    {
        public AddAuthorCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Length(3, 50);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);
        }
    }
}