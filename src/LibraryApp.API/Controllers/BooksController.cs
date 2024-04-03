using LibraryApp.Application.Books.Commands.Add;
using LibraryApp.Application.Books.Commands.Delete;
using LibraryApp.Application.Books.Commands.Update;
using LibraryApp.Application.Books.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class BooksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> Get([FromQuery]GetBookQuery query, CancellationToken token)
    {
        var result = await mediator.Send(query, token);
        return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
    }
    
    [HttpPost]
    public async Task<IResult> Add([FromBody]AddBookCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
    }
    
    [HttpPut]
    public async Task<IResult> Update([FromBody] UpdateBookCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
    }
    
    [HttpDelete]
    public async Task<IResult> Delete([FromBody]DeleteBookCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
    }
}