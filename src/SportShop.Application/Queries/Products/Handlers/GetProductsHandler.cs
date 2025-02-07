using MediatR;
using SportShop.Application.Abstractions;
using SportShop.Core.Entities;

namespace SportShop.Application.Queries.Products.Handlers;

public record ProductDto(Guid Id, string Name);

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;

public sealed class GetProductsHandler : IRequestHandler <GetProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsHandler(IProductRepository productRepository)
        => _productRepository = productRepository;

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken token)
        => await _productRepository.GetProductsAsync(token);
}