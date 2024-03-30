using MediatR;

namespace LibraryApp.Application.Books.Commands.Delete;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    public Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}