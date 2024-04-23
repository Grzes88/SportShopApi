using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportShop.Application.Abstractions;
using SportShop.Infrastructure.Repositories;

namespace SportShop.Infrastructure.DAL;

internal static class Extensions
{
    private const string OptionsSectionName = "MSql";

    public static IServiceCollection AddMSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MSqlOptions>(configuration.GetRequiredSection(OptionsSectionName));
        var mSqlOptions = configuration.GetOptions<MSqlOptions>(OptionsSectionName);
        services.AddDbContext<SportShopDbContext>(x => x.UseSqlServer(mSqlOptions.ConnectionString));

        services.AddHostedService<DatabaseInitializer>();

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
