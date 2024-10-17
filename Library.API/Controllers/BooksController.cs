using Library.Application.Book.Commands;
using Library.Application.Book.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public BooksController(IMediator mediator)
    { 
        _mediator = mediator;
    }

    [HttpPost] 
    public async Task<IActionResult> AddBook([FromBody] AddBookCommand command) 
    { 
        if (command == null) 
        { 
            return BadRequest("Invalid book data.");
        }
        
        var bookId = await _mediator.Send(command); 
        return CreatedAtAction(nameof(GetBookById), new { id = bookId }, command);
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var query = new GetBooksQuery();
        var books = await _mediator.Send(query);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var query = new GetBookByIdQuery(id);
        var book = await _mediator.Send(query);
        return Ok(book);
    }
}