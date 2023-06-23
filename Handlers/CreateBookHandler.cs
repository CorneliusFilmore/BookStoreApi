using BookStoreApi.Commands;
using BookStoreApi.Models;
using BookStoreApi.Repositories;
using MediatR;

namespace BookStoreApi.Handlers
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookHandler(IBookRepository booRepository)
        {
            _bookRepository = booRepository;
        }

        public async Task<Book> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book()
            {
                Id = command.Id,
                Authors = command.Authors,
                Description = command.Description,
                Title = command.Title,
            };

            return await _bookRepository.AddBookAsync(book);
        }
    }
}
