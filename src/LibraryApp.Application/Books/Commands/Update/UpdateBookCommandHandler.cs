using LibraryApp.Application.Common.Errors;
using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Books.Commands.Update;

public sealed class UpdateBookCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateBookCommand, Result>
{
    private CancellationToken _token;
    public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        _token = cancellationToken;
        var book = await uow.Books.GetByIdAsync(request.Id, cancellationToken);

        if (book is null)
        {
            return BookErrors.IdNotFound;
        }

        var results = new[]
        {
            TryChangeTitle(request, book),
            TryChangeDescription(request, book),
            TryChangeAuthor(request, book),
            TryChangePublicationDate(request, book)
        };

        if (results.FirstOrDefault(x => x.IsFailure) is { } result)
        {
            return result;
        }
        
        await uow.Books.Update(book, cancellationToken);
        await uow.CompleteAsync(cancellationToken);
        return Result.Success();
    }

    private Result TryChangePublicationDate(UpdateBookCommand request, Book book)
    {
        if (request.PublicationDate is not null)
        {
            book.PublicationDate = (DateTime)request.PublicationDate;
        }
        
        return Result.Success();
    }

    private Result TryChangeAuthor(UpdateBookCommand request, Book book)
    {
        if (request.AuthorId is not { } id) return Result.Success();
        
        var author = uow.Authors.GetByIdAsync(id, _token).GetAwaiter().GetResult();
        if (author is null)
        {
            return AuthorErrors.IdNotFound;
        }

        book.Author = author;

        return Result.Success();
    }

    private Result TryChangeDescription(UpdateBookCommand request, Book book)
    {
        if (request.Description is { } description)
        {
            book.Header.Description = description;
        }
        
        return Result.Success();
    }

    private Result TryChangeTitle(UpdateBookCommand request, Book book)
    {
        if (request.Title is not { } title) return Result.Success();
        
        if (!uow.Books.IsTitleUnique(title))
        {
            return BookErrors.NotUnique;
        }

        book.Header.Title = title;

        return Result.Success();
    }
}