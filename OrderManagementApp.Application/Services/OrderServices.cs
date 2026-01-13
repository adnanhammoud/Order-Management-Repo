using OrderManagementApp.Application.Repositories;
using OrderManagementApp.DTOs;
using OrderManagementApp.Models;

namespace OrderManagementApp.Application.Services;

public class OrderServices
{
    private readonly IOrderRepository _orderRepository;

    public OrderServices(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public Order CreateOrderAsync(OrderDTO orderDto)
    {
        Order order = _orderRepository.CreateOrder(orderDto);
        order.Status = "Pending";
        return order;
    }
}