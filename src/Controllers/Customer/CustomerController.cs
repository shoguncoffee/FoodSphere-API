using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Body;

namespace Customer.Controllers;

[Route("customer")]
[ApiController]
public class CustomerController(TableService tableService, OrderService orderService, SubOrderService subOrderService) : ControllerBase
{
    private readonly TableService _tableService = tableService;
    private readonly OrderService _orderService = orderService;
    private readonly SubOrderService _subOrderService = subOrderService;

    [HttpGet("/reserve/{id}")]
    public async Task Reserve(long id)
    {
        var table = await _tableService.Get(id);

        return;
    }
}