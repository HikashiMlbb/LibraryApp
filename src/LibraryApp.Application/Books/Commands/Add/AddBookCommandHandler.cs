using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Books.Commands.Add;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Result>
{
    public Task<Result> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}