using BookStoreApi.Commands;
using BookStoreApi.Repositories;
using MediatR;

namespace BookStoreApi.Handlers;

public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, int>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookByIdAsync(request.Id);

        return await _bookRepository.DeleteBookAsync(book.Id);
    }
}

