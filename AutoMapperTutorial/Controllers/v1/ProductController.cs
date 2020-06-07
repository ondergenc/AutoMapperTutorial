using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperTutorial.Contracts.v1.Requests;
using AutoMapperTutorial.Contracts.v1.Responses;
using AutoMapperTutorial.Domain;
using AutoMapperTutorial.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperTutorial.Controllers.v1
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("/api/v1/products")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetProductsAsync();
            var productsResponse = _mapper.Map<List<ProductResponse>>(products);
            return Ok(productsResponse);
        }

        [HttpGet("/api/v1/products/{productId}")]
        public async Task<IActionResult> GetAll([FromRoute] int productId)
        {
            var product = await _productService.GetProductAsync(productId);

            if (product == null) return NotFound("No record found");

            var productResponse = _mapper.Map<List<ProductResponse>>(product);
            return Ok(productResponse);
        }

        [HttpPost("api/v1/products")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest createProductRequest)
        {
            var product = new Product
            {
                ProductName = createProductRequest.ProductName
            };
            await _productService.CreateProductAsync(product);
            var productResponse = _mapper.Map<ProductResponse>(product);
            var uri = "api/v1/products/" + product.ProductId;
            return Created(uri, productResponse);
        }
    }
}
