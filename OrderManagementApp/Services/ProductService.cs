using OrderManagementApp.DTOs;
using OrderManagementApp.Models;

namespace OrderManagementApp.Services;

public class ProductService
{
    private AppDbContext _dbContext;

    public ProductService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

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

    public List<Product> GetAllProducts()
    {
        return _dbContext.Products.ToList();
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
}