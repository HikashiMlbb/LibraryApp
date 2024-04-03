using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Books.Commands.Update;

public sealed class UpdateBookCommand : IRequest<Result>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Guid? AuthorId { get; set; }
    public DateTime? PublicationDate { get; set; }
}