using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Books.Commands.Delete;

public sealed class DeleteBookCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}