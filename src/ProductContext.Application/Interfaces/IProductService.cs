using ProductContext.Domain.Dtos.ProductDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(CreateProductRequestDto dto);
        Task<GetProductsResponseDto> GetAsync(GetProductsRequestDto dto);
        Task<Product> GetAsync(Guid id);
    }
}
