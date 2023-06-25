using BookStoreApi.Commands;
using BookStoreApi.Models;
using BookStoreApi.Repositories;
using MediatR;

namespace BookStoreApi.Handlers;

public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand,Author>
{
    private readonly IAuthorRepository _authorRepository;

    public CreateAuthorHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    public async Task<Author> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        var author = new Author()
        {
            Id=command.Id,
            Name = command.Name,
            Surname = command.Surname
        };

        return await _authorRepository.AddAuthorAsync(author);
    }
}