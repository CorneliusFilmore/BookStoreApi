using BookStoreApi.Commands;
using BookStoreApi.Models;
using BookStoreApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBookAsync(Book book)
        {
            var bookToAdd = await _mediator.Send(new CreateBookCommand(
                book.Id,
                book.Title,
                book.Description,
                book.Authors ));

            return Ok(bookToAdd);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookListAsync()
        {
            var books = await _mediator.Send(new GetBookListQuery());
            
            return Ok(books);
        }
    }
}
