using FluentValidation;
using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Authors.Commands.Update;

public sealed class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .MinimumLength(Author.MinNameLength)
            .MaximumLength(Author.MaxNameLength);
    }
}