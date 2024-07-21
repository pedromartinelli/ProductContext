using Microsoft.EntityFrameworkCore;
using ProductContext.Domain.Dtos.ProductDtos;
using ProductContext.Domain.Entities;
using ProductContext.Domain.Interfaces;

namespace ProductContext.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<GetProductsResponseDto> GetAsync(GetProductsRequestDto dto)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Skip(dto.Page * dto.PageSize)
                .Take(dto.PageSize)
                .ToListAsync();

            var response = new GetProductsResponseDto
            {
                Page = dto.Page,
                PageSize = dto.PageSize,
                Total = products.Count,
                Products = products
            };

            return response;
        }

        public async Task<GetProductsResponseDto> GetAsync()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();

            var response = new GetProductsResponseDto
            {
                Total = products.Count,
                Products = products
            };

            return response;
        }

        public async Task<Product?> GetByIdAsync(Guid id)
            => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);


        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> VerifyNameAsync(string name)
            => await _context.Products.AnyAsync(p => p.Name == name);
    }
}
