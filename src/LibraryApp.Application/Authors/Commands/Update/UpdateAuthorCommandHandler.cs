using LibraryApp.Application.Common.Errors;
using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Commands.Update;

public sealed class UpdateAuthorCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateAuthorCommand, Result>
{
    public async Task<Result> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var foundAuthor = await uow.Authors.GetByIdAsync(request.Id, cancellationToken);

        if (foundAuthor is null)
        {
            return AuthorErrors.IdNotFound;
        }

        if (request.Name is not null)
        {
            var isUnique = uow.Authors.IsNameUnique(request.Name);
            if (!isUnique)
            {
                return AuthorErrors.NotUnique;
            }
            
            foundAuthor.Name = request.Name;
        }

        if (request.Books.Count > 0)
        {
            var books = new List<Book>();
            foreach (var book in request.Books)
            {
                var foundBook = await uow.Books.GetByIdAsync(book, cancellationToken);
                if (foundBook is null)
                {
                    return BookErrors.IdNotFound;
                }
                
                books.Add(foundBook);
            }

            foundAuthor.Books = books;
        }

        if (request.BirthDay is not null)
        {
            foundAuthor.BirthDay = (DateTime)request.BirthDay;
        }
        
        uow.Authors.Update(foundAuthor);
        await uow.CompleteAsync(cancellationToken);
        return Result.Success();
    }
}