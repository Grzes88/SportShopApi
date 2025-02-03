using MediatR;
using SportShop.Application.Abstractions;
using SportShop.Application.Exceptions;
using SportShop.Core.Entities;
using SportShop.Core.ValueObjects;

namespace SportShop.Application.Queries.Products.Handlers;

public record GetProductQuery(Guid productId) : IRequest<Product>;

public sealed class GetProductHandler : IRequestHandler<GetProductQuery, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductHandler(IProductRepository productRepository)
        => _productRepository = productRepository;

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken token)
        => await _productRepository.GetProductsAsync(token);

    public Task<Product> Handle(GetProductQuery request, CancellationToken token)
    {
        var productId = new ProductId(request.productId);
        var product = _productRepository.GetProductAsync(productId, token);

        if(product is null)
            throw new NotFoundProductException(productId);
        
        return product;
    }
}