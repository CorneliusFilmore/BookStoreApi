using BookStoreApi.Models;
using MediatR;

namespace BookStoreApi.Commands
{
    public class CreateBookCommand : IRequest<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Author> Authors { get; set; }

        public CreateBookCommand(int id, string title, string description, List<Author> authors)
        {
            Id = id;
            Title = title;
            Description = description;
            Authors = authors;
        }
    }
}
