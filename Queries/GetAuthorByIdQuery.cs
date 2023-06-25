using BookStoreApi.Models;
using MediatR;

namespace BookStoreApi.Queries
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public int Id { get; set; }

    }
}
