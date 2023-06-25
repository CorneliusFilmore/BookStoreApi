using BookStoreApi.Commands;
using BookStoreApi.Repositories;
using MediatR;

namespace BookStoreApi.Handlers;

public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, int>
{
    private readonly IAuthorRepository _authorRepository;

    public DeleteAuthorHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<int> Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
    {
        var authorToDelete = await _authorRepository.GetAuthorByIdAsync(command.Id);
        
        return await _authorRepository.DeleteAuthorAsync(authorToDelete.Id);
    }
}