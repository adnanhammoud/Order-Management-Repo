using OrderManagementApp.DTOs;
using OrderManagementApp.Migrations;
using OrderManagementApp.Models;

namespace OrderManagementApp.Services;

public class OrderService
{
    private AppDbContext _dbContext;
    
    private const string Pending = "Pending";
    private const string Paid = "Paid";
    private const string Cancelled = "Cancelled";

    public OrderService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Order CreateOrder(OrderDTO order)
    {
        var _order = new Order
        {
            CreatedAt = DateTime.UtcNow,
            Status = "Pending",
            BuyerName = order.BuyerName,
            Address = new Address
            {
                Line1 = order.Address.Line1,
                Line2 = order.Address.Line2,
                City = order.Address.City,
                State = order.Address.State,
                CountryCode = order.Address.CountryCode
            },
            OrderLines = new List<OrderLine>()
        };
        
        // n queries, query the lines then iterate over the list they are stored in.
        decimal sum = 0;
        foreach (var line in order.OrderLines)
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

    // public OrderDTO GetOrderById(int id)
    // {
    //     List<OrderLineDTO> orderLines = new List<OrderLineDTO>();
    //     var order = _dbContext.Orders.First(o => o.Id == id);
    //     return new OrderDTO()
    //     {
    //         BuyerName = order.BuyerName,
    //         Address = new AddressDTO()
    //         {
    //             Line1 = order.Address.Line1,
    //             Line2 = order.Address.Line2,
    //             City = order.Address.City,
    //             State = order.Address.State,
    //             CountryCode = order.Address.CountryCode
    //         },
    //         OrderLines = order.OrderLines.To,
    //     };
    // }

    public void DelteOrderById(int orderId)
    {
        var order = _dbContext.Orders.First(o => o.Id == orderId);
        if (order == null)
        {
            return;
        }
        _dbContext.Orders.Remove(order);
        _dbContext.SaveChanges();
    }

}   