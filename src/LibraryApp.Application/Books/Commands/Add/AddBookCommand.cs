using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Books.Commands.Add;

public class AddBookCommand : IRequest<Result>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public Guid? AuthorId { get; set; }
    public DateTime PublicationDate { get; set; }
}