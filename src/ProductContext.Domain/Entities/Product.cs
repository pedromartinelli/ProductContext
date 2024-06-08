namespace ProductContext.Domain.Entities;

public class Product : BaseEntity
{
    public Product(string name, string description, decimal price, int quantity)
    {
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        CreationRecord();
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public bool IsActive { get; private set; }
}
