

using ProductContext.Application.Dtos.Product;
using ProductContext.Application.Interfaces;
using ProductContext.Domain.Dtos.Products;
using ProductContext.Domain.Entities;
using ProductContext.Domain.Interfaces;

namespace ProductContext.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var existingName = await _repository.ProductNameExistsAsync(dto.Name);
            if (existingName) throw new ApplicationException("Já existe um produto cadastrado com esse nome!");

            var product = new Product(dto.Name, dto.Description, dto.Price, dto.Quantity);

            await _repository.RegisterAsync(product);
        }

        public async Task<GetProductsResponseDto> GetAsync(GetProductsDto dto)
        {
            if (dto.PageSize == 0)
            {
                return await _repository.GetAsync();
            }
            else
            {
                return await _repository.GetAsync(dto);
            }
        }
    }
}
