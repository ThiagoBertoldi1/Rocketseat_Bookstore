using Bookstore.Domain.Interfaces.Services;
using Bookstore.Domain.Requests.Books;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(
    IBookService bookService) : ControllerBase
{
    private readonly IBookService _bookService = bookService;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookRequest book, CancellationToken cancellationToken)
    {
        try
        {
            var created = await _bookService.Create(book, cancellationToken);

            return created ? Created() : BadRequest();
        }
        catch
        {
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookRequest book, CancellationToken cancellationToken)
    {
        try
        {
            var updated = await _bookService.Update(book, cancellationToken);

            return updated ? NoContent() : BadRequest();
        }
        catch
        {
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBookRequest book, CancellationToken cancellationToken)
    {
        try
        {
            var deleted = await _bookService.Delete(book.BookId, cancellationToken);

            return deleted ? NoContent() : BadRequest();
        }
        catch
        {
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            var books = await _bookService.GetAll(cancellationToken);

            return Ok(books);
        }
        catch
        {
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] Guid bookId, CancellationToken cancellationToken)
    {
        try
        {
            var book = await _bookService.GetById(bookId, cancellationToken);

            return book is not null ? Ok(book) : NotFound("Not found");
        }
        catch
        {
            return StatusCode(500, "An unexpected error occurred.");
        }
    }
}
