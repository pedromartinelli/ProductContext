using ProductContext.Domain.Dtos.ProductDtos;
using ProductContext.Domain.Entities;

namespace ProductContext.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> Create(CreateProductRequestDto dto);
        Task<GetProductsResponseDto> GetAll(GetProductsRequestDto dto);
        Task<Product> GetById(Guid id);
    }
}
