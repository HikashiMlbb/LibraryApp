using FluentValidation;
using LibraryApp.Domain.ValueObjects;

namespace LibraryApp.Application.Books.Commands.Add;

public sealed class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    public AddBookCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("A book must have a title.")
            .MinimumLength(BookHeader.MinTitleLength)
            .MaximumLength(BookHeader.MaxTitleLength);

        RuleFor(x => x.Description)
            .MaximumLength(BookHeader.MaxDescriptionLength)
            .WithMessage($"A book description length must be less than {BookHeader.MaxDescriptionLength}.");

        RuleFor(x => x.PublicationDate)
            .NotEmpty()
            .WithMessage("A book publication date mustn't be empty.");
    }
}