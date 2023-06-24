using BookStoreApi.Commands;
using BookStoreApi.Models;
using BookStoreApi.Repositories;
using MediatR;

namespace BookStoreApi.Handlers;

public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand,int>
{
    private readonly IAuthorRepository _authorRepository;

    public UpdateAuthorHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<int> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetAuthorByIdAsync(request.Id);

        if (author == null)
        {
            return 0;
        }

        author.Id = request.Id;
        author.Name = request.Name;
        author.Surname = request.Surname;
        
        return await _authorRepository.UpdateAuthorAsync(author);
    }
}