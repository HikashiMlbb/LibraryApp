using LibraryApp.Application.Common.Errors;
using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Shared;
using MediatR;
using IMapper = AutoMapper.IMapper;

namespace LibraryApp.Application.Books.Queries.Get;

public sealed class GetBookQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetBookQuery, Result<IEnumerable<BookModel>>>
{
    public async Task<Result<IEnumerable<BookModel>>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        if (request.Id is not null)
        {
            var book = await uow.Books.GetByIdAsync((Guid)request.Id, cancellationToken);

            return book is null
                ? BookErrors.IdNotFound
                : Result<IEnumerable<BookModel>>.Success([mapper.Map<BookModel>(book)]);
        }

        if (request.Title is not null)
        {
            var book = await uow.Books.GetByTitleAsync(request.Title, cancellationToken);

            return book is null
                ? BookErrors.TitleNotFound
                : Result<IEnumerable<BookModel>>.Success([mapper.Map<BookModel>(book)]);
        }

        if (request.AuthorId is not null)
        {
            var books = await uow.Books.GetByAuthorIdAsync((Guid)request.AuthorId, cancellationToken);
            return Result<IEnumerable<BookModel>>.Success(books.Select(mapper.Map<BookModel>));
        }

        var allBooks = await uow.Books.GetAllAsync(cancellationToken);
        return Result<IEnumerable<BookModel>>.Success(allBooks.Select(mapper.Map<BookModel>));
    }
}