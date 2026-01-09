using Microsoft.AspNetCore.Mvc;
using OrderManagementApp.DTOs;
using OrderManagementApp.Services;

namespace OrderManagementApp.Controllers;

[Route("api/orders")]
[ApiController]

public class OrderController : Controller
{
    private OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("create-order")]
    public IActionResult CreateOrder([FromBody] OrderDTO order)
    {
        _orderService.CreateOrder(order);
        return Ok();
    }

    [HttpDelete("delete-order/{id}")]
    public IActionResult DeleteOrder(int id)
    {
        _orderService.DelteOrderById(id);
        return Ok();
    }
}