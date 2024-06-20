namespace ProductContext.Application.Dtos.ProductDtos
{
    public class ProductDto
    {
        public ProductDto(string name, string description, decimal price, int quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
