using ProductContext.Application.Dtos.Product;
using ProductContext.Domain.Dtos.Products;

namespace ProductContext.Application.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(CreateProductDto dto);
        Task<GetProductsResponseDto> GetAsync(GetProductsDto dto);
    }
}
