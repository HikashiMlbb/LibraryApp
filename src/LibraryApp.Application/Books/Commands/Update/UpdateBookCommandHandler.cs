using MediatR;

namespace LibraryApp.Application.Books.Commands.Update;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    public Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}