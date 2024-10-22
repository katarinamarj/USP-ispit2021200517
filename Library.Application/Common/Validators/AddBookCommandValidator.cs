using Library.Application.Book.Commands;
using FluentValidation;

namespace Library.Application.Common.Validators;

public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    public AddBookCommandValidator()
    {
        RuleFor(x => x.BookId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).MinimumLength(3); 
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Genre).NotEmpty();
    }
}

