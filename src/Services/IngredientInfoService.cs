using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Body;

namespace FoodSphere.Services;

public class IngredientInfoService(FoodSphereContext context)
{
    private readonly FoodSphereContext _context = context;

    public async Task<List<IngredientInfo>> Gets()
    {
        return await _context.IngredientInfos.ToListAsync();
    }

    public async Task<IngredientInfo?> Get(long id)
    {
        return await _context.IngredientInfos.FindAsync(id);
    }

    public async Task Update(IngredientInfo ingredient)
    {
        _context.Entry(ingredient).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Add(IngredientInfo ingredient)
    {
        _context.IngredientInfos.Add(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var ingredient = await _context.IngredientInfos.FindAsync(id);

        if (ingredient == null) return;

        await Remove(ingredient);
    }

    public async Task Remove(IngredientInfo ingredient)
    {
        _context.IngredientInfos.Remove(ingredient);
        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.IngredientInfos.Any(e => e.Id == id);
    }
}