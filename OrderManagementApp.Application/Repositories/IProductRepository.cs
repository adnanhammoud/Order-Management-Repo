using OrderManagementApp.DTOs;
using OrderManagementApp.Models;

namespace OrderManagementApp.Application.Repositories;

public interface IProductRepository
{
    public ProductDTO GetProductById(int productId);
    
    public List<ProductDTO> GetAllProducts();
    
    public void AddProduct(ProductDTO product);
    
    public void DeleteProductById(int productId);
}