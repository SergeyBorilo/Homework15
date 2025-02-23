using System.ComponentModel.DataAnnotations;
using Library.Api.Domain.Books.Requests;
using Library.Application.Domain.Books.Commands.AssignBook;
using Library.Application.Domain.Books.Commands.CreateBook;
using Library.Application.Domain.Books.Commands.DeleteBook;
using Library.Application.Domain.Books.Commands.DeleteBookAuthor;
using Library.Application.Domain.Books.Commands.UpdateBook;
using Library.Application.Domain.Books.Queries.GetBookDetails;
using Library.Application.Domain.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Domain.Books;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BooksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetBooks(
    [FromQuery][Required] int page = 1,
    [FromQuery][Required] int pageSize = 10,
    CancellationToken cancellationToken = default)
    {
        var query = new GetBooksQuery(page, pageSize);
        var goods = await mediator.Send(query, cancellationToken);
        return Ok(goods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetBooksDetails(
    [FromRoute] Guid id,
    CancellationToken cancellationToken = default)
    {
        var query = new GetBookDetailsQuery(id);
        var good = await mediator.Send(query, cancellationToken);
        return Ok(good);
    }

    [HttpPost]
    public async Task<ActionResult> AddBooks(
    [FromBody][Required] CreateBookRequest request,
    CancellationToken cancellationToken = default)
    {
        var command = new CreateBookCommand(
            request.Title,
            request.Description);
        var id = await mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBooks(
    [FromRoute] Guid id,
    [FromBody][Required] UpdateBookRequest request,
    CancellationToken cancellationToken = default)
    {
        var command = new UpdateBookCommand(
           id,
           request.Title,
           request.Description);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBooks(
    [FromRoute] Guid id,
    CancellationToken cancellationToken = default)
    {
        var command = new DeleteBookCommand(id);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpPost("{id}/addBookAuthor")]
    public async Task<ActionResult> AssignBookAauthor(
    [FromRoute][Required] Guid bookId,
    [FromBody][Required] Guid authorId,
    CancellationToken cancellationToken = default)
    {
        var command = new AssignBookAuthorCommand(bookId, authorId);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}/deleteBookAuthor")]
    public async Task<ActionResult> RemoveBookAuthor(
        [FromRoute][Required] Guid bookId,
        [FromBody][Required] Guid authorId,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteBookAuthorCommand(bookId, authorId);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }
}
