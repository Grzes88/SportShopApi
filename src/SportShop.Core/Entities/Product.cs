using SportShop.Core.ValueObjects;

namespace SportShop.Core.Entities;

public class Product
{
    public ProductId Id { get; }
    public Name Name { get; private set; }
}