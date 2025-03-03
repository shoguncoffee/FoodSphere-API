using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Body;

namespace Manager.Controllers;

[Route("cooking")]
[ApiController]
public class CookingController(FoodService foodService, WaiterService waiterService, SubOrderService subOrderService) : ControllerBase
{
    private readonly FoodService _foodService = foodService;
    private readonly WaiterService _waiterService = waiterService;
    private readonly SubOrderService _subOrderService = subOrderService;

}