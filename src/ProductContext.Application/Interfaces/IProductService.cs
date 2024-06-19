
using ProductContext.Application.Dtos.Product;

namespace ProductContext.Application.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(CreateProductDto dto);
    }
}
