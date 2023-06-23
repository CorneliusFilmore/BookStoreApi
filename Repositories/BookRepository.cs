using BookStoreApi.Data;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly PostgressDBContext _dbContext;

        public BookRepository(PostgressDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var result = _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            var bookToDelete = _dbContext.Books.Where(x => x.Id == id).FirstOrDefault();
            var result = _dbContext.Books.Remove(bookToDelete);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetBookListAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<int> UpdateBookAsync(Book book)
        {
            _dbContext.Books.Update(book);
            return await _dbContext.SaveChangesAsync();
        }

    }
}
