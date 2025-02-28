using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;

namespace FoodSphere.Controllers;

[Route("[controller]")]
[ApiController]
public class RestaurantController(RestaurantService restaurantService) : ControllerBase
{
    private readonly RestaurantService _restaurantService = restaurantService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
    {
        var restaurants = await _restaurantService.Gets();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurant(long id)
    {
        var restaurant = await _restaurantService.Get(id);

        if (restaurant == null)
        {
            return NotFound();
        }

        return restaurant;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutRestaurant(long id, Restaurant restaurant)
    {
        if (id != restaurant.Id)
        {
            return BadRequest();
        }

        try
        {
            await _restaurantService.Update(restaurant);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_restaurantService.Exists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurantbody)
    {
        var restaurant = new Restaurant
        {
            Name = restaurantbody.Name,
            Email = restaurantbody.Email,
            Phone = restaurantbody.Phone
        };

        await _restaurantService.Add(restaurant);

        return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant(long id)
    {
        var restaurant = await _restaurantService.Get(id);
        if (restaurant == null)
        {
            return NotFound();
        }

        await _restaurantService.Remove(restaurant);

        return NoContent();
    }
}
