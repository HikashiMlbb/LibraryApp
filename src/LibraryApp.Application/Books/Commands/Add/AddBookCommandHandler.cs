using MediatR;

namespace LibraryApp.Application.Books.Commands.Add;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand>
{
    public Task Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}