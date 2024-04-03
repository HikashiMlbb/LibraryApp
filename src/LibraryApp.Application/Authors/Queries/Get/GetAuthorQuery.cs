using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Queries.Get;

public sealed class GetAuthorQuery : IRequest<Result<IEnumerable<AuthorModel>>>
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public Guid? BookId { get; set; }
}