using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductContext.Domain.Entities;

namespace ProductContext.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAsync();
        Task<Product> GetAsync(int id);
        Task<bool> VerifyDuplicateNameAsync(string name);
        void Create(Product product);
        void Update(Product product);
        void Deactivate(int id);
    }
}
