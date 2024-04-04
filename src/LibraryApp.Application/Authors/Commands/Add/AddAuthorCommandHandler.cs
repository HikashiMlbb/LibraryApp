using LibraryApp.Application.Common.Errors;
using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Commands.Add;

public sealed class AddAuthorCommandHandler(IUnitOfWork uow) : IRequestHandler<AddAuthorCommand, Result>
{
    public async Task<Result> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        var isUnique = uow.Authors.IsNameUnique(request.Name);
        if (!isUnique)
        {
            return AuthorErrors.NotUnique;
        }

        var author = new Author(
            Guid.NewGuid(),
            request.Name,
            request.BirthDay);

        if (request.Books.Count > 0)
        {
            var books = new List<Book>();

            foreach (var bookId in request.Books)
            {
                var foundBook = await uow.Books.GetByIdAsync(bookId, cancellationToken);

                if (foundBook is null)
                {
                    return BookErrors.IdNotFound;
                }
                
                books.Add(foundBook);
            }
            
            uow.Books.Attach(books);
            author.Books = books;
        }

        uow.Authors.Add(author);
        await uow.CompleteAsync(cancellationToken);
        return Result.Success();
    }
}