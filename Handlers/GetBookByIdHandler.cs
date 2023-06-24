using BookStoreApi.Models;
using BookStoreApi.Queries;
using BookStoreApi.Repositories;
using MediatR;

namespace BookStoreApi.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        { 
            return await _bookRepository.GetBookByIdAsync(request.Id);
        }
    }
}
