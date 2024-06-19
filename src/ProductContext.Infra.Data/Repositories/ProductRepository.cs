using ProductContext.Domain.Dtos.Products;
using ProductContext.Domain.Entities;
using ProductContext.Domain.Interfaces;
using ProductContext.Infra.Data.Mocks;

namespace ProductContext.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task DeactivateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetProductsResponseDto> GetAsync(GetProductsDto dto)
        {
            var mockedProducts = ProductsMock.GetMockProducts();

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
            var mockedProducts = ProductsMock.GetMockProducts();
            var products = mockedProducts.ToList();

            var response = new GetProductsResponseDto
            {
                Total = products.Count,
                Products = products,
            };

            return response;
        }

        public async Task<Product> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(Product product)
        {
            return;
        }

        public async Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ProductNameExistsAsync(string name)
        {
            return false;
        }
    }
}
