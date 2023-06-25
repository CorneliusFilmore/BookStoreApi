using BookStoreApi.Models;
using MediatR;

namespace BookStoreApi.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }

    }
}
