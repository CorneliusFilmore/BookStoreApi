using BookStoreApi.Models;
using BookStoreApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Author>> GetAuthorListAsync()
        {
            var authors = await _mediator.Send(new GetAuthorListQuery());

            return authors;
        }

        [HttpGet("{id}")]
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery() { Id = id });

            return author;
        }
    }
}
