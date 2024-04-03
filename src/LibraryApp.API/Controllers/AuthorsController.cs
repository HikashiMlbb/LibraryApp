using LibraryApp.Application.Authors.Commands.Add;
using LibraryApp.Application.Authors.Commands.Delete;
using LibraryApp.Application.Authors.Commands.Update;
using LibraryApp.Application.Authors.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public sealed class AuthorsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> Get([FromQuery] GetAuthorQuery query, CancellationToken token)
    {
        var result = await mediator.Send(query, token);
        if (result.IsFailure)
        {
            return result.Error!.Code == "Author.NotFound"
                ? Results.NotFound(result.Error)
                : Results.BadRequest(result.Error);
        }

        return Results.Ok(result.Value);
    }
    
    [HttpPost]
    public async Task<IResult> Add([FromBody]AddAuthorCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IResult> Update([FromBody] UpdateAuthorCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
    }

    [HttpDelete]
    public async Task<IResult> Delete([FromBody]DeleteAuthorCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
    }
}