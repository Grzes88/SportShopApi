namespace SportShop.Core.Exceptions;

public sealed class InvalidNameException : CustomException
{
    public string Name { get; }

    public InvalidNameException(string name) : base($"name: '{name}' is invalid.")
        => Name = name;
}
