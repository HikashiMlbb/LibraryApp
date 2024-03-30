using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Queries.Get;

public class GetAuthorQuery : IRequest<Result<IEnumerable<Author>>>
{
    
}