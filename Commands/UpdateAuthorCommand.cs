using BookStoreApi.Models;
using MediatR;

namespace BookStoreApi.Commands;

public class UpdateAuthorCommand : IRequest<int>
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public UpdateAuthorCommand(int id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }

}