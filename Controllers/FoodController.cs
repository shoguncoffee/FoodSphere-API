using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Types;

namespace FoodSphere.Controllers;

[Route("[controller]")]
[ApiController]
public class FoodController(FoodService foodService) : ControllerBase
{
    private readonly FoodService _foodService = foodService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
    {
        return Ok(await _foodService.Gets());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Food>> GetFood(long id)
    {
        var food = await _foodService.Get(id);

        if (food == null)
        {
            return NotFound();
        }

        return food;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFood(long id, Food food)
    {
        if (id != food.Id)
        {
            return BadRequest();
        }

        try
        {
            await _foodService.Update(food);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_foodService.Exists(id))
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
    public async Task<ActionResult<Food>> PostFood(FoodBody foodbody)
    {
        var food = new Food
        {
            Name = foodbody.Name,
            Price = foodbody.Price,
        };

        await _foodService.Add(food, foodbody.Items);

        return CreatedAtAction("GetFood", new { id = food.Id }, food);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFood(long id)
    {
        var food = await _foodService.Get(id);
        if (food == null)
        {
            return NotFound();
        }

        await _foodService.Remove(food);

        return NoContent();
    }
}