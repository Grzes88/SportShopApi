using SportShop.Core.Exceptions;

namespace SportShop.Application.Exceptions;

public class NotFoundProductException : CustomException
{
    public Guid Id { get; set; }

    public NotFoundProductException(Guid id) : base($"ProductId: {id} not found")
        => Id = id;
}