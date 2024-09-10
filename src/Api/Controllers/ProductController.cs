using CleanArchitecture.MyShop.Application.Interfaces;
using CleanArchitecture.MyShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MyShop.Api.Controllers
{
    // API Controller for Products -v1
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetProductsById([FromRoute] int id)
        {
            var response = await _productService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var response = await _productService.CreateProductAsync(product);
            return Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var response = await _productService.UpdateProductAsync(product);
            return Ok(response);
        }
    }
}
