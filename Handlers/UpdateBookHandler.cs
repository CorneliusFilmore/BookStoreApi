using BookStoreApi.Commands;
using BookStoreApi.Repositories;
using MediatR;

namespace BookStoreApi.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
           _bookRepository = bookRepository;
        }

        public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.Id);

            if (book == null)
            {
                return 0;
            }

            book.Id = request.Id;
            book.Title = request.Title;
            book.Description = request.Description;
            book.Authors = request.Authors;

            return await _bookRepository.UpdateBookAsync(book);
        }
    }
}
