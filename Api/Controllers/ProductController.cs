using Application.Dtos.products;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponse>>> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductResponse>> GetById(Guid id)
        {
            var request = new GetProductRequest
            {
                ProductId = id
            };
            
            try
            {
                var product = await _productService.GetProductByIdAsync(request);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AddProductResponse>> Create([FromBody] AddProductRequest request)
        {
            try
            {
                var result = await _productService.AddProductAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = result.ProductId }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] EditProductRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID in URL doesn't match ID in request body");

            try
            {
                await _productService.EditProductAsync(request);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var request = new RemoveProductRequest
                {
                    ProductId = id
                };
                
                await _productService.RemoveProductAsync(request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
} 