using BookStoreApi.Commands;
using BookStoreApi.Models;
using BookStoreApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAuthorListAsync()
        {
            var authors = await _mediator.Send(new GetAuthorListQuery());

            return Ok(authors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthorByIdAsync(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery { Id = id });

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAuthorAsync(Author author)
        {
            var authorToAdd = await _mediator.Send(new CreateAuthorCommand(
                author.Id,
                author.Name,
                author.Surname
            ));

            return CreatedAtAction("GetAuthorById", "Author", new { id = authorToAdd.Id }, authorToAdd);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAuthorAsync(int id)
        {
            var authorToDelete = await _mediator.Send(new DeleteAuthorCommand(id));

            if (authorToDelete == null)
            {
                return NotFound($"Author by the id {authorToDelete} does not exisit");
            }

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateStudentAsync(Author author)
        {
            var authorToUpdate = await _mediator.Send(new UpdateAuthorCommand(author.Id, author.Name, author.Surname));
           
            if (authorToUpdate == 0)
            {
                return NotFound($"Author by the id does not exisit");
            }
            
            return Ok($"Author by the Id:{authorToUpdate} was updated");
        }
    }
}
