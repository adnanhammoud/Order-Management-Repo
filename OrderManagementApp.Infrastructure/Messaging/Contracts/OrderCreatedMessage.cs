namespace OrderManagementApp.Infrastructure.Messaging.Contracts;

public class OrderCreatedMessage
{
    public int id { get; set; }
    public string BuyerName { get; set; }
    public decimal TotalPrice { get; set; }
}