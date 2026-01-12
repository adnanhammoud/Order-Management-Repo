using OrderManagementApp.Application.Repositories;
using OrderManagementApp.DTOs;
using OrderManagementApp.Models;

namespace OrderManagementApp.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;
    public Order CreateOrder(OrderDTO orderDTO)
    {
        var _order = new Order
        {
            CreatedAt = DateTime.UtcNow,
            Status = "Pending",
            BuyerName = orderDTO.BuyerName,
            Address = new Address
            {
                Line1 = orderDTO.Address.Line1,
                Line2 = orderDTO.Address.Line2,
                City = orderDTO.Address.City,
                State = orderDTO.Address.State,
                CountryCode = orderDTO.Address.CountryCode
            },
            OrderLines = new List<OrderLine>()
        };
        
        // n queries, query the lines then iterate over the list they are stored in.
        decimal sum = 0;
        foreach (var line in orderDTO.OrderLines)
        {
            var product = _dbContext.Products.First(p => p.Id == line.ProductId);

            var unitPrice = Convert.ToDecimal(product.Price);
            var totalPrice = unitPrice * line.Quantity;

            _order.OrderLines.Add(new OrderLine
            {
                ProductName = product.Name,
                UnitPrice = unitPrice,
                Quantity = line.Quantity,
                TotalPrice = totalPrice
            });
            sum += totalPrice;
        }

        _order.TotalAmount = sum;

        _dbContext.Orders.Add(_order);
        _dbContext.SaveChanges();

        return _order;
    }

    public Order GetOrderById(int orderId)
    {
        return _dbContext.Orders.First(o => o.Id == orderId);
    }

    public void DeleteOrderById(int orderId)
    {
        var order = _dbContext.Orders.First(o => o.Id == orderId);
        _dbContext.Orders.Remove(order);
        _dbContext.SaveChanges();
    }
}