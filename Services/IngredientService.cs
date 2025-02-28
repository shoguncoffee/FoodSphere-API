using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Types;

namespace FoodSphere.Services;

public class IngredientService(FoodSphereContext context)
{
    private readonly FoodSphereContext _context = context;

    public async Task<IEnumerable<Ingredient>> Gets()
    {
        return await _context.Ingredients.ToListAsync();
    }

    public async Task<Ingredient?> Get(long id)
    {
        return await _context.Ingredients.FindAsync(id);
    }

    public async Task Update(Ingredient ingredient)
    {
        _context.Entry(ingredient).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Add(Ingredient ingredient)
    {
        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);

        if (ingredient == null) return;

        await Remove(ingredient);
    }

    public async Task Remove(Ingredient ingredient)
    {
        _context.Ingredients.Remove(ingredient);
        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.Ingredients.Any(e => e.Id == id);
    }
}