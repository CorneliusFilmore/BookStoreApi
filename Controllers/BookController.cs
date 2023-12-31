﻿using BookStoreApi.Commands;
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery() { Id = id });

            if(book == null)
                return NotFound($"Book with Id:{id} does not exisit");

            return Ok(book);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            var bookToDelete = await _mediator.Send(new DeleteBookCommand(id));

            if (bookToDelete == null)
            {
                return NotFound($"Author by the id {bookToDelete} does not exisit");
            }

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateBookAsync(Book book)
        {
            var bookToUpdate = await _mediator.Send(new UpdateBookCommand(book.Id, book.Title, book.Description, book.Authors));

            if (bookToUpdate == 0)
            {
                return NotFound($"book by the id does not exist");
            }

            return Ok($"Author by the Id:{bookToUpdate} was updated");
        }
    }
}
