using BookStoreApi.Data;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly PostgressDBContext _dbContext;
        public AuthorRepository(PostgressDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            var result = _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAuthorAsync(int id)
        {
            var authorToDelete = _dbContext.Authors.Where(x => x.Id == id).FirstOrDefault();
            var result = _dbContext.Authors.Remove(authorToDelete);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _dbContext.Authors.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Author>> GetAuthorListAsync()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<int> UpdateAuthorAsync(Author author)
        {
            _dbContext.Authors.Update(author);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
