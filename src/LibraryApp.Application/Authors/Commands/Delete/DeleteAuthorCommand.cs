using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Commands.Delete;

public sealed class DeleteAuthorCommand : IRequest<Result>
{
    public Guid Id { get; set; }   
}