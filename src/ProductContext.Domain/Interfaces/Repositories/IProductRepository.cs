using ProductContext.Domain.Entities;

namespace ProductContext.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAsync();
        Task<Product> GetAsync(int id);
        Task<bool> ProductNameExistsAsync(string name);
        Task RegisterAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeactivateAsync(int id);
    }
}
