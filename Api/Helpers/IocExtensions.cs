using Application.Services;
using Domain.Common;
using Domain.Products.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Helpers
{
    public static class IocExtensions
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var conStr = configuration.GetConnectionString("DefaultConStrSqlServer");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(conStr));
        }
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
