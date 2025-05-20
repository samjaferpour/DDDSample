using Application.Dtos.products;

namespace Application.Services
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetAllProductsAsync();
        Task<ProductResponse> GetProductByIdAsync(GetProductRequest request);
        Task<AddProductResponse> AddProductAsync(AddProductRequest request);
        Task EditProductAsync(EditProductRequest request);
        Task RemoveProductAsync(RemoveProductRequest request);
    }
}
