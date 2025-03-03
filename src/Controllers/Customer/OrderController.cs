using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Body;

namespace Customer.Controllers;

[Route("customer")]
[ApiController]
public class OrderController(TableService tableService, OrderService orderService, SubOrderService subOrderService) : ControllerBase
{
    private readonly TableService _tableService = tableService;
    private readonly OrderService _orderService = orderService;
    private readonly SubOrderService _subOrderService = subOrderService;

    [HttpGet("/order/{id}")]
    public async Task Order(long id)
    {
        var order = await _orderService.Get(id);

        return;
    }
}