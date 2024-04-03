using FluentValidation;
using LibraryApp.Domain.ValueObjects;

namespace LibraryApp.Application.Books.Queries.Get;

public sealed class GetBookQueryValidator : AbstractValidator<GetBookQuery>
{
    public GetBookQueryValidator()
    {
        RuleFor(x => x.Title)
            .Length(BookHeader.MinTitleLength, BookHeader.MaxTitleLength)
            .When(x => x.Title != null);
    }
}