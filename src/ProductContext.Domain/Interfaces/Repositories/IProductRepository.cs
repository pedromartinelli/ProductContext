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
        Task<ICollection<Product>> Get();
        Task<Product> Get(int id);
        void Create(Product product);
        void Update(Product product);
        void Deactivate(int id);
    }
}
