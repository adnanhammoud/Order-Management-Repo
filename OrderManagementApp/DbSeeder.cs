using System;
using System.Linq;
using OrderManagementApp;
using OrderManagementApp.Models;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        // Safety: do not reseed
        if (context.Orders.Any())
            return;

        // --------------------
        // Customers
        // --------------------
        var customer1 = new Customer
        {
            Name = "Ahmad Hammoud"
        };

        var customer2 = new Customer
        {
            Name = "John Doe"
        };

        context.Customers.Add(customer1);
        context.Customers.Add(customer2);

        // --------------------
        // Addresses
        // --------------------
        var address1 = new Address
        {
            Line1 = "Hamra Street",
            Line2 = "Building 12",
            City = "Beirut",
            State = "Beirut",
            CountryCode = "LB"
        };

        context.Addresses.Add(address1);

        // --------------------
        // Products
        // --------------------
        var product1 = new Product
        {
            Name = "Laptop",
            Description = "Business Laptop",
            Sku = "LAP-001",
            Price = 1200m
        };

        var product2 = new Product
        {
            Name = "Mouse",
            Description = "Wireless Mouse",
            Sku = "MOU-001",
            Price = 25m
        };

        context.Products.AddRange(product1, product2);

        // --------------------
        // Orders
        // --------------------
        var order1 = new Order
        {
            CreatedAt = DateTime.UtcNow,
            Status = "Pending",
            Customer = customer1,        // navigation
            CustomerId = customer1.Id,   // FK (explicit, safe)
            Address = address1,
            TotalAmount = 1250m,
            OrderLines = new List<OrderLine>()
        };

        // --------------------
        // Order Lines
        // --------------------
        var orderLine1 = new OrderLine
        {
            Order = order1,
            ProductName = product1.Name,
            UnitPrice = product1.Price,
            Quantity = 1,
            TotalPrice = product1.Price
        };

        var orderLine2 = new OrderLine
        {
            Order = order1,
            ProductName = product2.Name,
            UnitPrice = product2.Price,
            Quantity = 2,
            TotalPrice = product2.Price * 2
        };

        order1.OrderLines.Add(orderLine1);
        order1.OrderLines.Add(orderLine2);

        context.Orders.Add(order1);

        context.SaveChanges();
    }
}
