using AutoMapper;
using LibraryApp.Application.Common.Errors;
using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Queries.Get;

public sealed class GetAuthorQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetAuthorQuery, Result<IEnumerable<AuthorModel>>>
{
    public async Task<Result<IEnumerable<AuthorModel>>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        if (request.Id is not null)
        {
            var found = await uow.Authors.GetByIdAsync((Guid)request.Id, cancellationToken);
            return found is null 
                ? AuthorErrors.IdNotFound 
                : Result<IEnumerable<AuthorModel>>.Success([mapper.Map<AuthorModel>(found)]);
        }

        if (request.Name is not null)
        {
            var found = await uow.Authors.GetByNameAsync(request.Name, cancellationToken);
            return found is null 
                ? AuthorErrors.NameNotFound
                : Result<IEnumerable<AuthorModel>>.Success([mapper.Map<AuthorModel>(found)]);
        }

        if (request.BookId is not null)
        {
            var found = await uow.Authors.GetByBookIdAsync((Guid)request.BookId, cancellationToken);
            return found is null
                ? AuthorErrors.BookNotFound
                : Result<IEnumerable<AuthorModel>>.Success([mapper.Map<AuthorModel>(found)]); 
        }

        return Result<IEnumerable<AuthorModel>>.Success(
            (await uow.Authors.GetAllAsync(cancellationToken))
            .Select(mapper.Map<AuthorModel>));
    }
}