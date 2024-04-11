using LibraryApp.Application.Books.Commands.Add;
using LibraryApp.Application.Books.Commands.Delete;
using LibraryApp.Application.Books.Commands.Update;
using LibraryApp.Application.Books.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class BooksController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Gets the list of books.
    /// </summary>
    /// <param name="query">GetBookQuery object</param>
    /// <param name="token">Cancellation Token</param>
    /// <remarks>
    ///     Firstly, it will try to find books by ID. If ID is null, it will try to find books by title.
    ///     If title is null, it will try to find books by Author Id. It all properties are null, it will return all books.
    /// </remarks>
    /// <returns>Result of list of BookModel</returns>
    /// <response code="200">Success</response>
    /// <response code="204">Success without data</response>
    /// <response code="404">Not found by specified criterion</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> Get([FromQuery]GetBookQuery query, CancellationToken token)
    {
        var result = await mediator.Send(query, token);
        if (result.IsFailure)
        {
            return Results.BadRequest(result.Error);
        }

        return result.Value!.Any()
            ? Results.Ok(result.Value)
            : Results.NoContent();
    }
    /// <summary>
    ///     Creates the book to the database.
    /// </summary>
    /// <param name="command"><see cref="AddBookCommand"/> object</param>
    /// <param name="token">Cancellation Token</param>
    /// <response code="201">The book is successfully created</response>
    /// <response code="400">Failed to create the book</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> Add([FromBody]AddBookCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result.IsSuccess ? Results.Created() : Results.BadRequest(result.Error);
    }
    
    /// <summary>
    ///     Updates the book by given parameters
    /// </summary>
    /// <param name="command"><see cref="UpdateBookCommand"/> object</param>
    /// <param name="token">Cancellation Token</param>
    /// <response code="204">Successfully updated</response>
    /// <response code="400">Failed to update the book</response>
    /// <response code="404">Book not found</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> Update([FromBody] UpdateBookCommand command, CancellationToken token)
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
    ///     Deletes the book with specified ID
    /// </summary>
    /// <param name="command"><see cref="DeleteBookCommand"/> object</param>
    /// <param name="token">Cancellation Token</param>
    /// <response code="204">Successfully deleted</response>
    /// <response code="404">Book with such ID is not found</response>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> Delete([FromBody]DeleteBookCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
    }
}