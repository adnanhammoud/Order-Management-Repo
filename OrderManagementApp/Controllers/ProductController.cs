using Microsoft.AspNetCore.Mvc;
using OrderManagementApp.DTOs;
using OrderManagementApp.Services;

namespace OrderManagementApp.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : Controller
{
    private ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("get-product-by-id/{id}")]
    public IActionResult GetProductById(int id)
    {
        var _product = _productService.GetProductById(id);
        return Ok(_product);
    }

    [HttpGet("get-all-products")]
    public IActionResult GetAllProducts()
    {
        var _products = _productService.GetAllProducts();
        return Ok(_products);
    }

    [HttpPost("add-product")]
    public IActionResult AddProduct([FromBody] ProductDTO product)
    {
        _productService.AddProduct(product);
        return Ok();
    }
}