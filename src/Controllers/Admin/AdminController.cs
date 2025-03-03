using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Body;

namespace Admin.Controllers;

[Route("admin")]
[ApiController]
public class AdminController(RestaurantService restaurantService) : ControllerBase
{
    private readonly RestaurantService _restaurantService = restaurantService;


}