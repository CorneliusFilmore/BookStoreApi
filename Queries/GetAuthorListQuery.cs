using BookStoreApi.Models;
using MediatR;

namespace BookStoreApi.Queries
{
    public class GetAuthorListQuery : IRequest<List<Author>>
    {
    }
}
