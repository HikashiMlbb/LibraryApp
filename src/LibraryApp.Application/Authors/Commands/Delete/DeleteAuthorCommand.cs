using System.ComponentModel.DataAnnotations;
using LibraryApp.Domain.Shared;
using MediatR;

namespace LibraryApp.Application.Authors.Commands.Delete;

public sealed class DeleteAuthorCommand : IRequest<Result>
{
    [Required]
    public Guid Id { get; set; }   
}