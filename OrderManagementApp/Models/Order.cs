namespace OrderManagementApp.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; }
    public Address Address { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderLine> OrderLines { get; set; }
}