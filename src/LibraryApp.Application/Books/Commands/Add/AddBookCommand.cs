using System.ComponentModel.DataAnnotations;
using LibraryApp.Domain.Shared;
using LibraryApp.Domain.ValueObjects;
using MediatR;

namespace LibraryApp.Application.Books.Commands.Add;

public sealed class AddBookCommand : IRequest<Result>
{
    [Required]
    [MinLength(BookHeader.MinTitleLength)]
    [MaxLength(BookHeader.MaxTitleLength)]
    public string Title { get; set; } = null!;
    
    [MaxLength(BookHeader.MaxDescriptionLength)]
    public string? Description { get; set; }
    public Guid? AuthorId { get; set; }
    [Required] public DateTime PublicationDate { get; set; }
}