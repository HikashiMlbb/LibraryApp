using FluentValidation;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.ValueObjects;

namespace LibraryApp.Application.Books.Commands.Update;

public sealed class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        
        RuleFor(x => x.Title)
            .Length(Author.MinNameLength, Author.MaxNameLength)
            .When(x => x.Title != null)
            .WithMessage(
                $"The title length must be between {Author.MinNameLength} and {Author.MaxNameLength} if not null.");

        RuleFor(x => x.Description)
            .MaximumLength(BookHeader.MaxDescriptionLength);
    }
}