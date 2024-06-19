using ProductContext.Domain.Dtos.Products;
using ProductContext.Domain.Entities;

namespace ProductContext.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<GetProductsResponseDto> GetAsync();
        Task<GetProductsResponseDto> GetAsync(GetProductsDto dto);
        Task<Product> GetAsync(int id);
        Task<bool> ProductNameExistsAsync(string name);
        Task RegisterAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeactivateAsync(int id);
    }
}
