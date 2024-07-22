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

        public async Task<Product> Create(CreateProductRequestDto dto)
        {
            var existingName = await _repository.VerifyNameAsync(dto.Name);
            if (existingName) throw new ApplicationException("Já existe um produto cadastrado com esse nome.");

            var product = new Product(dto.Name, dto.Description, dto.Price, dto.Quantity);

            await _repository.CreateAsync(product);

            return product;
        }

        public async Task<GetProductsResponseDto> GetAll(GetProductsRequestDto dto)
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

        public async Task<Product> GetById(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) throw new ApplicationException("Não existe um produto com o Id informado.");
            return product;
        }
    }
}
