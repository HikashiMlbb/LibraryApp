using MediatR;

namespace LibraryApp.Application.Authors.Commands.Delete;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
{
    public Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}