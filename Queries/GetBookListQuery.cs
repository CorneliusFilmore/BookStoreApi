using BookStoreApi.Models;
using MediatR;

namespace BookStoreApi.Queries;

public class GetBookListQuery : IRequest<List<Book>>
{
    
}