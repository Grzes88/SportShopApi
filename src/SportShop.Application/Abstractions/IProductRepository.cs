using SportShop.Core.Entities;
using SportShop.Core.ValueObjects;

namespace SportShop.Application.Abstractions;

public interface IProductRepository
{
    Task AddProductAsync(Product product, CancellationToken token);

    Task<IEnumerable<Product>> GetProductsAsync(CancellationToken token);

    Task<Product?> GetProductAsync(ProductId id, CancellationToken token);
}