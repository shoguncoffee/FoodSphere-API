using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Body;

namespace Manager.Controllers;

[Route("manager")]
[ApiController]
public class ManagerController(TableService tableService, WaiterService waiterService, SubOrderService subOrderService) : ControllerBase
{
    private readonly TableService _tableService = tableService;
    private readonly WaiterService _waiterService = waiterService;
    private readonly SubOrderService _subOrderService = subOrderService;

}