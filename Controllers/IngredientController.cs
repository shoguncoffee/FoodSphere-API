using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Types;

namespace FoodSphere.Controllers;

[Route("[controller]")]
[ApiController]
public class IngredientController(IngredientService ingredientService) : ControllerBase
{
    private readonly IngredientService _ingredientService = ingredientService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
    {
        return Ok(await _ingredientService.Gets());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ingredient>> GetIngredient(long id)
    {
        var ingredient = await _ingredientService.Get(id);

        if (ingredient == null)
        {
            return NotFound();
        }

        return ingredient;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutIngredient(long id, Ingredient ingredient)
    {
        if (id != ingredient.Id)
        {
            return BadRequest();
        }

        try
        {
            await _ingredientService.Update(ingredient);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_ingredientService.Exists(id))
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
    public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
    {

        await _ingredientService.Add(ingredient);

        return CreatedAtAction("GetIngredient", new { id = ingredient.Id }, ingredient);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredient(long id)
    {
        var ingredient = await _ingredientService.Get(id);
        if (ingredient == null)
        {
            return NotFound();
        }

        await _ingredientService.Remove(ingredient);

        return NoContent();
    }
}
