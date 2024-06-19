using ProductContext.Domain.Entities;
using ProductContext.Domain.Interfaces;

namespace ProductContext.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task DeactivateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Product>> GetAsync()
        {
            throw new NotImplementedException();
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

        public async Task<bool> VerifyDuplicateNameAsync(string name)
        {
            return false;
        }
    }
}
