using Library.Application.Author.Commands;
using Library.Application.Author.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAuthor([FromBody] AddAuthorCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var query = new GetAllAuthorsQuery();
        var author = await _mediator.Send(query);
        return Ok(author);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorById(string id)
    {
        var query = new GetAuthorByIdQuery(id);
        var author = await _mediator.Send(query);
        if (author == null) return NotFound();
        return Ok(author);
    }
}



