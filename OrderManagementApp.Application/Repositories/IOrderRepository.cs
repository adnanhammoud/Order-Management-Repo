using OrderManagementApp.Models;

namespace OrderManagementApp.Application.Repositories;
    
public interface IOrderRepository
{
    public Order CreateOrder();
    
    public Order GetOrderById(int orderId);
    
    public void DeleteOrderById(int orderId);
}