using LibraryApp.Application.Common.Errors;
using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Books.Commands.Delete;

public sealed class DeleteBookCommandHandler(IUnitOfWork uow) : IRequestHandler<DeleteBookCommand, Result>
{
    public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await uow.Books.GetByIdAsync(request.Id, cancellationToken);
        if (book is null)
        {
            return BookErrors.IdNotFound;
        }
        
        uow.Books.Delete(book);
        await uow.CompleteAsync(cancellationToken);
        return Result.Success();
    }
}