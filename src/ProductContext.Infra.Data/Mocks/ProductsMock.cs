using ProductContext.Domain.Entities;

namespace ProductContext.Infra.Data.Mocks
{
    public class ProductsMock
    {
        public static List<Product> GetMockProducts()
        {
            var products = new List<Product>
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

            return products;
        }

        //public static List<ProductDto> GetMockProducts()
        //{
        //    var products = new List<ProductDto>
        //    {
        //        new ProductDto("Produto 1", "Descrição", 20, 2),
        //        new ProductDto("Produto 2", "Descrição", 20, 2),
        //        new ProductDto("Produto 3", "Descrição", 20, 2),
        //        new ProductDto("Produto 4", "Descrição", 20, 2),
        //        new ProductDto("Produto 5", "Descrição", 20, 2),
        //        new ProductDto("Produto 6", "Descrição", 20, 2),
        //        new ProductDto("Produto 7", "Descrição", 20, 2),
        //        new ProductDto("Produto 8", "Descrição", 20, 2),
        //        new ProductDto("Produto 9", "Descrição", 20, 2),
        //        new ProductDto("Produto 10", "Descrição", 20, 2),
        //        new ProductDto("Produto 11", "Descrição", 20, 2),
        //        new ProductDto("Produto 12", "Descrição", 20, 2),
        //        new ProductDto("Produto 13", "Descrição", 20, 2),
        //        new ProductDto("Produto 14", "Descrição", 20, 2),
        //        new ProductDto("Produto 15", "Descrição", 20, 2),
        //    };

        //    return products;
        //}
    }
}