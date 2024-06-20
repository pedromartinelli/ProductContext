using ProductContext.Domain.Dtos.ProductDtos;
using ProductContext.Domain.Entities;
using ProductContext.Domain.Interfaces;
using ProductContext.Infra.Data.Mocks;

namespace ProductContext.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsMock _mock;

        public ProductRepository(ProductsMock mock)
        {
            _mock = mock;
        }

        public async Task DeactivateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetProductsResponseDto> GetAsync(GetProductsDto dto)
        {
            var mockedProducts = _mock.GetMockProducts();

            var products = mockedProducts.Skip(dto.Page * dto.PageSize).Take(dto.PageSize).ToList();
            var total = mockedProducts.Count;

            var response = new GetProductsResponseDto
            {
                Page = dto.Page,
                PageSize = dto.PageSize,
                Total = total,
                Products = products,
            };

            return response;
        }

        public async Task<GetProductsResponseDto> GetAsync()
        {
            var mockedProducts = _mock.GetMockProducts();
            var products = mockedProducts.ToList();

            var response = new GetProductsResponseDto
            {
                Total = products.Count,
                Products = products,
            };

            return response;
        }

        public async Task<Product?> GetAsync(Guid id)
        {
            var mockedProducts = _mock.GetMockProducts();

            return await Task.Run(() => mockedProducts.FirstOrDefault(p => p.Id == id));
        }

        public async Task<Product> RegisterAsync(Product product)
        {
            var mockedProducts = _mock.GetMockProducts();

            await Task.Run(() => mockedProducts.Add(product));

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ProductNameExistsAsync(string name)
        {
            var mockedProducts = _mock.GetMockProducts();

            return await Task.Run(() => mockedProducts.Any(x => x.Name == name));
        }
    }
}
