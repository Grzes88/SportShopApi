using SportShop.Core.ValueObjects;

namespace SportShop.Core.Entities;

public class Product
{
    public ProductId Id { get; }
    public Name Name { get; private set; }

    public Product(ProductId id, Name name)
    {
        Id = id;
        Name = name;
    }

    public static Product Create(Name name)
        => new(Guid.NewGuid(), name);
}