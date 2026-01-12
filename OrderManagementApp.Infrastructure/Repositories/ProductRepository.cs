using OrderManagementApp.Application.Repositories;
using OrderManagementApp.DTOs;
using OrderManagementApp.Models;

namespace OrderManagementApp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;
    public ProductDTO GetProductById(int productId)
    {
        var product = _dbContext.Products.Where(p => p.Id == productId).Select(product => new ProductDTO()
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            Sku = product.Sku,
        }).FirstOrDefault();
    
        return product;
    }

    public List<ProductDTO> GetAllProducts()
    {
        var _products = _dbContext.Products.Select(product => new ProductDTO()
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            Sku = product.Sku,
        }).ToList();
        
        return _products;
    }

    public void AddProduct(ProductDTO product)
    {
        var _product = new Product()
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            Sku = product.Sku,
        };
        _dbContext.Products.Add(_product);
        _dbContext.SaveChanges();
    }

    public void DeleteProductById(int productId)
    {
        var _product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
        if (_product != null)
        {
            _dbContext.Products.Remove(_product);
            _dbContext.SaveChanges();
        }
    }
     
}