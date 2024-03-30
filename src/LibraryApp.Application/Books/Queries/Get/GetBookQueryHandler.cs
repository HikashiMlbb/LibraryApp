using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Books.Queries.Get;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, Result<IEnumerable<Book>>>
{
    public Task<Result<IEnumerable<Book>>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}