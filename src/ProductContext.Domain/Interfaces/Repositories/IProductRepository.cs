using ProductContext.Domain.Dtos.ProductDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<GetProductsResponseDto> GetAsync();
        Task<GetProductsResponseDto> GetAsync(GetProductsRequestDto dto);
        Task<Product?> GetAsync(Guid id);
        Task<bool> ProductNameExistsAsync(string name);
        Task<Product> RegisterAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeactivateAsync(int id);
    }
}
