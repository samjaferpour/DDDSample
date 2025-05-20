using Domain.Products.Entities;

namespace Domain.Products.Repositories
{
    public interface IProductRepository
    {
        Task<Product> SelectByIdAsync(Guid id);
        Task<List<Product>> SelectAllAsync();
        Task<Guid> InsertAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}
