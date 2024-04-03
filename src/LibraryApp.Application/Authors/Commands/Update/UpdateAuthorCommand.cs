using System.ComponentModel.DataAnnotations;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Commands.Update;

public sealed class UpdateAuthorCommand : IRequest<Result>
{
    [Required]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public IReadOnlyCollection<Guid> Books { get; set; } = new List<Guid>();
    public DateTime? BirthDay { get; set; }
}