using LibraryApp.Application.Common.Errors;
using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using LibraryApp.Domain.ValueObjects;
using MediatR;

namespace LibraryApp.Application.Books.Commands.Add;

public sealed class AddBookCommandHandler(IUnitOfWork uow) : IRequestHandler<AddBookCommand, Result>
{
    public async Task<Result> Handle(AddBookCommand request, CancellationToken token)
    {
        if (!uow.Books.IsTitleUnique(request.Title))
            return BookErrors.NotUnique;

        Author? author = null;
        if (request.AuthorId is not null)
        {
            author = await uow.Authors.GetByIdAsync((Guid)request.AuthorId, token);
            
            if (author is null) return AuthorErrors.IdNotFound;
        }
        
        var book = new Book(
            Guid.NewGuid(),
            new BookHeader(request.Title, request.Description),
            request.PublicationDate,
            author);

        uow.Books.Add(book);
        await uow.CompleteAsync(token);
        return Result.Success();
    }
}