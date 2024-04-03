using LibraryApp.Application.Common.Errors;
using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Commands.Delete;

public sealed class DeleteAuthorCommandHandler(IUnitOfWork uow) : IRequestHandler<DeleteAuthorCommand, Result>
{
    public async Task<Result> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await uow.Authors.GetByIdAsync(request.Id, cancellationToken);
        if (author is null)
        {
            return AuthorErrors.IdNotFound;
        }

        uow.Authors.Delete(author);
        await uow.CompleteAsync(cancellationToken);
        return Result.Success();
    }
}