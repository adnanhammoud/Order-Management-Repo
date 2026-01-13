using OrderManagementApp.DTOs;
using OrderManagementApp.Models;
using Riok.Mapperly.Abstractions;

namespace OrderManagementApp.Application.Mappings;

[Mapper]
public partial class ProductMapper
{
    public partial ProductDTO ToProductDto(Product product);
    
    public partial List<ProductDTO> ToProductDtos(IEnumerable<Product> products);

}