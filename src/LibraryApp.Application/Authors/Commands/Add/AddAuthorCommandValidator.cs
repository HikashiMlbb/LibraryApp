using FluentValidation;
using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Authors.Commands.Add;

public sealed class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
{
    public AddAuthorCommandValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(Author.MinNameLength)
            .MaximumLength(Author.MaxNameLength);

        RuleFor(x => x.BirthDay);

        RuleFor(x => x.Books);
    }
}