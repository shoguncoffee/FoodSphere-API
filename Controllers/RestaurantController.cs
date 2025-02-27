using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;

namespace FoodSphere.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController : ControllerBase
{
    private readonly FoodSphereContext _context;

    public RestaurantController(FoodSphereContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
    {
        return await _context.Restaurants.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurant(long id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);

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

        _context.Entry(restaurant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RestaurantExists(id))
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
    public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
    {
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant(long id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null)
        {
            return NotFound();
        }

        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RestaurantExists(long id)
    {
        return _context.Restaurants.Any(e => e.Id == id);
    }
}
