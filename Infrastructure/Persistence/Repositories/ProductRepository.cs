using Domain.Products.Entities;
using Domain.Products.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _appDbContext.Products
                                             .Where(x => x.Id == id)
                                             .FirstOrDefaultAsync();
            _appDbContext.Products.Remove(product);
        }

        public async Task<Guid> InsertAsync(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            return product.Id;
        }

        public async Task<List<Product>> SelectAllAsync()
        {
            var products = await _appDbContext.Products.ToListAsync();
            return products;
        }

        public async Task<Product> SelectByIdAsync(Guid id)
        {
            var product = await _appDbContext.Products
                                             .Where(x => x.Id == id)
                                             .FirstOrDefaultAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _appDbContext.Products.Update(product);
        }
    }
}
