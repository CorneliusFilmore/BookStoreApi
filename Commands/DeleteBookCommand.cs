using MediatR;

namespace BookStoreApi.Commands;

public class DeleteBookCommand : IRequest<int>
{
    public int Id { get; set; }

    public DeleteBookCommand(int id)
    {
        Id = id;
    }
}
