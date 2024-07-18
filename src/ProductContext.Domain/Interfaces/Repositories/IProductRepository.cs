using ProductContext.Domain.Dtos.ProductDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<GetProductsResponseDto> GetAsync();
        Task<GetProductsResponseDto> GetAsync(GetProductsRequestDto dto);
        Task<Product?> GetByIdAsync(Guid id);
        Task<bool> VerifyNameAsync(string name);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
    }
}
