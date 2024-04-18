using SportShop.Core.Exceptions;

namespace SportShop.Core.ValueObjects;

public sealed record Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
            throw new InvalidNameException(value);

        Value = value;
    }

    public static implicit operator string(Name name)
    => name.Value;

    public static implicit operator Name(string value)
        => new(value);

    public override string ToString() => Value;
}
