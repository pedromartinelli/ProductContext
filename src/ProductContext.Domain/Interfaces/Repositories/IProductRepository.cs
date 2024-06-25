using ProductContext.Domain.Dtos.ProductDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<GetProductsResponseDto> GetAll();
        Task<GetProductsResponseDto> GetAll(GetProductsRequestDto dto);
        Task<Product?> GetById(Guid id);
        Task<bool> ProductNameExists(string name);
        Task<Product> Register(Product product);
        Task<Product> Update(Product product);
        Task Deactivate(int id);
    }
}
