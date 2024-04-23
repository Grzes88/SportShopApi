using SportShop.Application.Abstractions;
using SportShop.Core.Entities;
using SportShop.Infrastructure.DAL;

namespace SportShop.Infrastructure.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly SportShopDbContext _dbContext;

    public ProductRepository(SportShopDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task AddProductAsync(Product product, CancellationToken token)
    {
        await _dbContext.Products.AddAsync(product, token);
        await _dbContext.SaveChangesAsync(token);
    }
}
