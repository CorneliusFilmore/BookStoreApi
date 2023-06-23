using BookStoreApi.Models;

namespace BookStoreApi.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthorAsync(Author author);
        Task<int> DeleteAuthorAsync(int id);
        Task<Author> GetAuthorByIdAsync(int id);
        Task<List<Author>> GetAuthorListAsync();
        Task<int> UpdateAuthorAsync(Author author);
    }
}