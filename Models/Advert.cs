namespace BookStoreApi.Models
{
    public class Advert
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public List<Book> Books { get; set; }

    }
}
