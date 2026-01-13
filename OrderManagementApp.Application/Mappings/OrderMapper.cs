using OrderManagementApp.DTOs;
using OrderManagementApp.Models;
using Riok.Mapperly.Abstractions;

namespace OrderManagementApp.Application.Mappings;

[Mapper]
public partial class OrderMapper
{
    public partial OrderDTO ToOrderDto(Order order);
    
}