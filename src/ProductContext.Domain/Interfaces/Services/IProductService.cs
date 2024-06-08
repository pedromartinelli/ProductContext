using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductContext.Domain.Dtos.Product;

namespace ProductContext.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IServiceResult> CreateAsync(CreateProductDto dto);
    }
}
