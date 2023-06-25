using MediatR;

namespace BookStoreApi.Commands;

public class DeleteAuthorCommand : IRequest<int>
{
    public int Id { get; set; }

    public DeleteAuthorCommand(int id)
    {
        Id = id;
    }
}