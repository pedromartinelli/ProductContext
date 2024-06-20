using ProductContext.Domain.Dtos.ProductDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(CreateProductDto dto);
        Task<GetProductsResponseDto> GetAsync(GetProductsDto dto);
        Task<Product> GetAsync(Guid id);
    }
}
