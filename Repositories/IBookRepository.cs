using BookStoreApi.Models;

namespace BookStoreApi.Repositories
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book book);
        Task<int> DeleteBookAsync(int id);
        Task<Book> GetBookByIdAsync(int id);
        Task<List<Book>> GetBookListAsync();
        Task<int> UpdateBookAsync(Book book);
    }
}