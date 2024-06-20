using ProductContext.Domain.Entities;

namespace ProductContext.Infra.Data.Mocks
{
    public class ProductsMock
    {
        private static List<Product> _mockProducts;

        public ProductsMock()
        {
            _mockProducts = new List<Product>
            {
                new Product("Produto 1", "Descrição", 20, 2),
                new Product("Produto 2", "Descrição", 20, 2),
                new Product("Produto 3", "Descrição", 20, 2),
                new Product("Produto 4", "Descrição", 20, 2),
                new Product("Produto 5", "Descrição", 20, 2),
                new Product("Produto 6", "Descrição", 20, 2),
                new Product("Produto 7", "Descrição", 20, 2),
                new Product("Produto 8", "Descrição", 20, 2),
                new Product("Produto 9", "Descrição", 20, 2),
                new Product("Produto 10", "Descrição", 20, 2),
                new Product("Produto 11", "Descrição", 20, 2),
                new Product("Produto 12", "Descrição", 20, 2),
                new Product("Produto 13", "Descrição", 20, 2),
                new Product("Produto 14", "Descrição", 20, 2),
                new Product("Produto 15", "Descrição", 20, 2),
            };
        }

        public List<Product> GetMockProducts()
        {
            return _mockProducts;
        }
    }
}