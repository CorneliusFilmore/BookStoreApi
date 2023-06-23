﻿using BookStoreApi.Commands;
using BookStoreApi.Models;
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
        public async Task<Book> AddBookAsync(Book book)
        {
            var bookToAdd = await _mediator.Send(new CreateBookCommand(
                book.Id,
                book.Title,
                book.Description,
                book.Authors ));

            return bookToAdd;
        }
    }
}
