using OrderManagementApp.Models;

namespace OrderManagementApp.Application.Repositories;

public interface IProductRepository
{
    public Product GetProductById(int productId);
    
    public List<Product> GetProducts();
    
    public void AddProduct(Product product);
    
    public void DeleteProductById(int productId);
}