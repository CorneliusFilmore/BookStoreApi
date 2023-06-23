using BookStoreApi.Models;
using BookStoreApi.Queries;
using BookStoreApi.Repositories;
using MediatR;

namespace BookStoreApi.Handlers
{
    public class GetAuthorListHandler : IRequestHandler<GetAuthorListQuery, List<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorListHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAuthorListAsync();
        }
    }
}
