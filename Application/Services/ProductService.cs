using Application.Dtos.products;
using Domain.Common;
using Domain.Products.Entities;
using Domain.Products.Repositories;
using Domain.Products.ValueObjects;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository,
                              IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AddProductResponse> AddProductAsync(AddProductRequest request)
        {
            var product = new Product(
                name: request.Name,
                price: new Money(request.Price),
                categoryName: request.CategoryName,
                categoryCreator: request.CategoryCreator
            );

            var id = await _productRepository.InsertAsync(product);
            await _unitOfWork.CommitAllAsync();

            return new AddProductResponse
            {
                ProductId = id,
            };
        }


        public async Task EditProductAsync(EditProductRequest request)
        {
            var product = await _productRepository.SelectByIdAsync(request.Id);
            if (product == null)
                throw new InvalidOperationException($"Product with ID {request.Id} not found.");
                
            product.UpdateName(request.Name);
            product.UpdatePrice(new Money(request.Price));
            product.UpdateCategory(request.CategoryName, request.CategoryCreator);
            
            await _productRepository.UpdateAsync(product);
            await _unitOfWork.CommitAllAsync();
        }

        public async Task<List<ProductResponse>> GetAllProductsAsync()
        {
            var response = await _productRepository.SelectAllAsync();
            return response.Select(x => new ProductResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price.Amount,
                    CategoryName = x.Category.Name,
                    CategoryCreator = x.Category.Creator
                })
                .ToList();
        }

        public async Task<ProductResponse> GetProductByIdAsync(GetProductRequest request)
        {
            var product = await _productRepository.SelectByIdAsync(request.ProductId);
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.Amount,
                CategoryName = product.Category.Name,
                CategoryCreator = product.Category.Creator
            };
        }

        public async Task RemoveProductAsync(RemoveProductRequest request)
        {
            await _productRepository.DeleteAsync(request.ProductId);
            await _unitOfWork.CommitAllAsync();
        }
    }
}
