using OrderManagementApp.DTOs;
using OrderManagementApp.Models;

namespace OrderManagementApp.Application.Repositories;
    
public interface IOrderRepository
{
    public Order CreateOrder(OrderDTO orderDto);
    
    public Order GetOrderById(int orderId);
    
    public void DeleteOrderById(int orderId);
}