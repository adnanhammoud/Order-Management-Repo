namespace OrderManagementApp.DTOs;

public class OrderDTO
{
    public string BuyerName { get; set; }
    public AddressDTO Address { get; set; }
    public List<OrderLineDTO> OrderLines { get; set; }
}