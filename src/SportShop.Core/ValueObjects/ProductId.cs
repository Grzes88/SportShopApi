using SportShop.Core.Exceptions;

namespace SportShop.Core.ValueObjects;

public sealed record ProductId
{
    public Guid Value { get; }

    public ProductId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityIdException(value);

        Value = value;
    }

    public static implicit operator Guid(ProductId date)
        => date.Value;

    public static implicit operator ProductId(Guid value)
        => new(value);

    public override string ToString() => Value.ToString();
}
