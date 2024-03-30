using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Books.Queries.Get;

public class GetBookQuery : IRequest<Result<IEnumerable<Book>>>
{
    
}