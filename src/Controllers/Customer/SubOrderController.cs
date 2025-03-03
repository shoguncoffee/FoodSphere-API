using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Body;

namespace Customer.Controllers;

[Route("customer")]
[ApiController]
public class SubOrderController(TableService tableService, OrderService orderService, SubOrderService subOrderService) : ControllerBase
{
    private readonly TableService _tableService = tableService;
    private readonly OrderService _orderService = orderService;
    private readonly SubOrderService _subOrderService = subOrderService;

    [HttpGet("/suborder/{id}")]
    public async Task SubOrder(long id)
    {
        var subOrder = await _subOrderService.Get(id);

        return;
    }
}