using MediatR;
using SportShop.Application.Abstractions;
using SportShop.Core.Entities;

namespace SportShop.Application.Commands.Products.Handlers;

public record CreateProductCommand(string Name) : IRequest;

public sealed class CreateProductHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
        => _productRepository = productRepository;

    public async Task Handle(CreateProductCommand request, CancellationToken token)
    {
        var product = Product.Create(request.Name);
        await _productRepository.AddProductAsync(product, token);
    }
}