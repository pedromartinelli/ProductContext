using ProductContext.Domain.Entities;

namespace ProductContext.Domain.Dtos.ProductDtos
{
    public class GetProductsResponseDto
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int Total { get; set; }
        public ICollection<Product> Products { get; set; } = [];
    }
}
