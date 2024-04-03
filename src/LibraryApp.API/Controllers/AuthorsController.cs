using LibraryApp.Application.Authors.Commands.Add;
using LibraryApp.Application.Authors.Commands.Delete;
using LibraryApp.Application.Authors.Commands.Update;
using LibraryApp.Application.Authors.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
[Produces("application/json")]
public sealed class AuthorsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Gets the list of authors.
    /// </summary>
    /// <remarks>
    ///     Firstly, it will find author by ID. If not specified, it will find author by name.
    ///     If not specified, it will find author by book id. If nothing is specified, returns all list of authors
    /// </remarks>
    /// <param name="query"><see cref="GetAuthorQuery"/> object</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>Result of list of <see cref="AuthorModel"/></returns>
    /// <response code="200">Success</response>
    /// <response code="204">Success without data</response>
    /// <response code="404">Author is not found by specified criterion</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> Get([FromQuery] GetAuthorQuery query, CancellationToken token)
    {
        var result = await mediator.Send(query, token);
        if (result.IsFailure)
        {
            return result.Error!.Code.Contains("NotFound")
                ? Results.NotFound(result.Error)
                : Results.BadRequest(result.Error);
        }

        return result.Value!.Any()
            ? Results.Ok(result.Value)
            : Results.NoContent();
    }
    
    /// <summary>
    ///     Creates the author to the database
    /// </summary>
    /// <param name="command"><see cref="AddAuthorCommand"/> object</param>
    /// <param name="token">Cancellation token</param>
    /// <response code="201">Successfully created</response>
    /// <response code="400">Failed to create</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> Add([FromBody]AddAuthorCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result.IsSuccess ? Results.Created() : Results.BadRequest(result.Error);
    }
    
    /// <summary>
    ///     Updates the author data in the database
    /// </summary>
    /// <param name="command"><see cref="UpdateAuthorCommand"/> object</param>
    /// <param name="token">Cancellation token</param>
    /// <response code="204">Successfully updated</response>
    /// <response code="400">Failed to update</response>
    /// <response code="404">Not found</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> Update([FromBody] UpdateAuthorCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);

        if (result.IsFailure)
        {
            return result.Error!.Code.Contains("NotFound")
                ? Results.NotFound(result.Error)
                : Results.BadRequest(result.Error);
        }
        
        return Results.NoContent();
    }

    /// <summary>
    ///     Deletes the author from the database
    /// </summary>
    /// <param name="command"><see cref="DeleteAuthorCommand"/> object</param>
    /// <param name="token">Cancellation token</param>
    /// <response code="204">Successfully deleted</response>
    /// <response code="400">Failed to delete</response>
    /// <response code="404">Author is not found</response>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> Delete([FromBody]DeleteAuthorCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
    }
}