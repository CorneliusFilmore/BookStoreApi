using BookStoreApi.Models;
using BookStoreApi.Queries;
using BookStoreApi.Repositories;
using MediatR;

namespace BookStoreApi.Handlers;

public class GetBookListHandler : IRequestHandler<GetBookListQuery,List<Book>>
{
    private readonly IBookRepository _bookRepository;

    public GetBookListHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }


    public async Task<List<Book>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository.GetBookListAsync();
    }
}