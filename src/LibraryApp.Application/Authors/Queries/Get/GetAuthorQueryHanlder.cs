using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Queries.Get;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, Result<IEnumerable<Author>>>
{
    public Task<Result<IEnumerable<Author>>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}