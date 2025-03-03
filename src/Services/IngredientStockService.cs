using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Body;

namespace FoodSphere.Services;

public class IngredientStockService(FoodSphereContext context)
{
    private readonly FoodSphereContext _context = context;

    public async Task<List<IngredientStock>> Gets()
    {
        return await _context.IngredientStocks.ToListAsync();
    }

    public async Task<IngredientStock?> Get(long id)
    {
        return await _context.IngredientStocks.FindAsync(id);
    }

    public async Task Update(IngredientStock ingredient)
    {
        _context.Entry(ingredient).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Add(IngredientStock ingredient)
    {
        _context.IngredientStocks.Add(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var ingredient = await _context.IngredientStocks.FindAsync(id);

        if (ingredient == null) return;

        await Remove(ingredient);
    }

    public async Task Remove(IngredientStock ingredient)
    {
        _context.IngredientStocks.Remove(ingredient);
        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.IngredientStocks.Any(e => e.Id == id);
    }
}