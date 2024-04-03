using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Books.Queries.Get;

public sealed class GetBookQuery : IRequest<Result<IEnumerable<BookModel>>>
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public Guid? AuthorId { get; set; }
}