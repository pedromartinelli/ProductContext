using ProductContext.Application.Interfaces;
using ProductContext.Domain.Dtos.ProductDtos;
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

        public async Task<Product> CreateAsync(CreateProductRequestDto dto)
        {
            var existingName = await _repository.ProductNameExistsAsync(dto.Name);
            if (existingName) throw new ApplicationException("Já existe um produto cadastrado com esse nome.");

            var product = new Product(dto.Name, dto.Description, dto.Price, dto.Quantity);

            await _repository.RegisterAsync(product);

            return product;
        }

        public async Task<GetProductsResponseDto> GetAsync(GetProductsRequestDto dto)
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

        public Task<Product> GetAsync(Guid id)
        {
            var product = _repository.GetAsync(id);
            if (product.Result == null) throw new ApplicationException("Não existe um produto com o Id informado.");
            return product;
        }
    }
}
