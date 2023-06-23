using BookStoreApi.Models;

namespace BookStoreApi.Repositories
{
    public interface IAdvertRepository
    {
        Task<Advert> AddAdvertAsync(Advert advert);
        Task<int> DeleteAdvertAsync(int id);
        Task<Advert> GetAdvertByIdAsync(int id);
        Task<List<Advert>> GetAdvertListAsync();
        Task<int> UpdateAdvertAsync(Advert advert);
    }
}