using BookStoreApi.Data;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Repositories
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly PostgressDBContext _dbContext;
        public AdvertRepository(PostgressDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<Advert> AddAdvertAsync(Advert advert)
        {
            var result = _dbContext.Adverts.Add(advert);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAdvertAsync(int id)
        {
            var advertToDelte = _dbContext.Adverts.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Adverts.Remove(advertToDelte);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Advert> GetAdvertByIdAsync(int id)
        {
            return await _dbContext.Adverts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Advert>> GetAdvertListAsync()
        {
            return await _dbContext.Adverts.ToListAsync();
        }

        public async Task<int> UpdateAdvertAsync(Advert advert)
        {
            _dbContext.Adverts.Update(advert);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
