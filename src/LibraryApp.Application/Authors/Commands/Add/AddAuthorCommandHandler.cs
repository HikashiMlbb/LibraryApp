using MediatR;

namespace LibraryApp.Application.Authors.Commands.Add;

public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand>
{
    public Task Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}