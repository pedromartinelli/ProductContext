using ProductContext.Domain.Dtos.Product;

namespace ProductContext.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task CreateAsync(CreateProductDto dto);
    }
}
