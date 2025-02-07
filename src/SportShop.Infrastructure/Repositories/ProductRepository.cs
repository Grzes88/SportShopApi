using Microsoft.EntityFrameworkCore;
using SportShop.Application.Abstractions;
using SportShop.Core.Entities;
using SportShop.Core.ValueObjects;
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

    public async Task<Product?> GetProductAsync(ProductId id,  CancellationToken token)
        => await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id, token);
    
    public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken token)
        => await _dbContext.Products.ToListAsync(token);
}