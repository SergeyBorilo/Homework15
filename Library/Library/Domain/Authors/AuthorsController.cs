using System.ComponentModel.DataAnnotations;
using Library.Api.Constants;
using Library.Api.Domain.Authors.Requests;
using Library.Application.Domain.Authors.Commands.CreateAuthor;
using Library.Application.Domain.Authors.Commands.DeleteAuthor;
using Library.Application.Domain.Authors.Commands.UpdateAuthor;
using Library.Application.Domain.Authors.Queries.GetAuthors;
using Library.Application.Domain.Authors.Queries.GetAuthorsDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Domain.Authors;

[Authorize]
[Route(Routes.Authors)]
[ApiController]
public class AuthorsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAuthors(
        [FromQuery][Required] int page = 1,
        [FromQuery][Required] int perPage = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAuthorsQuery(page, perPage);
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetAuthor(
        Guid id, CancellationToken cancellationToken)
    {
        var query = new GetAuthorDetailsQuery(id);
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAuthor(
        [FromBody] CreateAuthorRequest request,
        CancellationToken cancellationToken)
    {

        var command = new CreateAuthorCommand(
                request.FirstName,
                request.LastName,
                request.MiddleName);
        var authorId = await mediator.Send(command, cancellationToken);
        return Ok(authorId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Guid>> UpdateAuthor(
        Guid id, [FromBody] UpdateAuthorRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateAuthorCommand(id, request.FirstName, request.LastName, request.MiddleName);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthor(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteAuthorCommand(id), cancellationToken);
        return Ok();
    }
}

