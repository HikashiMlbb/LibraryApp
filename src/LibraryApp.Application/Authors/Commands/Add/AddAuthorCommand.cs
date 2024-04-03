using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Commands.Add;

public sealed class AddAuthorCommand : IRequest<Result>
{
    public string Name { get; set; }
    public DateTime BirthDay { get; set; }
    public ICollection<Guid> Books { get; set; } = new List<Guid>();
}