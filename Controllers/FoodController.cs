using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;

namespace FoodSphere.Controllers;

[Route("food")]
[ApiController]
public class FoodController : ControllerBase
{
    private readonly FoodSphereContext _context;

    public FoodController(FoodSphereContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Food>>> GetFoodItems()
    {
        return await _context.Foods.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Food>> GetFoodItem(long id)
    {
        var foodItem = await _context.Foods.FindAsync(id);

        if (foodItem == null)
        {
            return NotFound();
        }

        return foodItem;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFoodItem(long id, Food foodItem)
    {
        if (id != foodItem.Id)
        {
            return BadRequest();
        }

        _context.Entry(foodItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FoodItemExists(id))
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
    public async Task<ActionResult<Food>> PostFoodItem(Food foodItem)
    {
        _context.Foods.Add(foodItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFoodItem", new { id = foodItem.Id }, foodItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFoodItem(long id)
    {
        var foodItem = await _context.Foods.FindAsync(id);
        if (foodItem == null)
        {
            return NotFound();
        }

        _context.Foods.Remove(foodItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FoodItemExists(long id)
    {
        return _context.Foods.Any(e => e.Id == id);
    }
}
