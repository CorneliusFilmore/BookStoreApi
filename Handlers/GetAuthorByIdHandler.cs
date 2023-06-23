using BookStoreApi.Models;
using BookStoreApi.Queries;
using BookStoreApi.Repositories;
using MediatR;

namespace BookStoreApi.Handlers
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorByIdHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAuthorByIdAsync(request.Id);
        }
    }
}
