using MediatR;

namespace LibraryApp.Application.Authors.Commands.Update;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
{
    public Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}