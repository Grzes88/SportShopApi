using SportShop.Core.Entities;

namespace SportShop.Application.Abstractions;

public interface IProductRepository
{
    Task AddProductAsync(Product product, CancellationToken token);

    Task<IEnumerable<Product>> GetProductsAsync(CancellationToken token);
}
