using System.ComponentModel.DataAnnotations;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Books.Commands.Delete;

public sealed class DeleteBookCommand : IRequest<Result>
{
    [Required]
    public Guid Id { get; set; }
}