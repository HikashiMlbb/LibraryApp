using Carter;
using LibraryApp.Application.Books.Commands.Add;
using MediatR;

namespace LibraryApp.API.Endpoints;

public class BookEndpoints : CarterModule
{
    public BookEndpoints() : base("/api/books") 
    {
        
    }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (AddBookCommand command, CancellationToken token, IMediator mediator) =>
        {
            var result = await mediator.Send(command, token);
            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
        });
    }
}