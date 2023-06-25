using BookStoreApi.Models;
using MediatR;

namespace BookStoreApi.Commands;

public class CreateAuthorCommand : IRequest<Author>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public CreateAuthorCommand(int id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }
}