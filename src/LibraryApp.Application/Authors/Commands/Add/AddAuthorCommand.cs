using System.ComponentModel.DataAnnotations;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Commands.Add;

public sealed class AddAuthorCommand : IRequest<Result>
{
    [Required]
    [MinLength(Author.MinNameLength)]
    [MaxLength(Author.MaxNameLength)]
    public string Name { get; set; } = null!;
    
    [Required] public DateTime BirthDay { get; set; }
    public ICollection<Guid> Books { get; set; } = new List<Guid>();
}