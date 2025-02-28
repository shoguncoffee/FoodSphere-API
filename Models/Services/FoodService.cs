using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Body;

namespace FoodSphere.Services;

public class FoodService(FoodSphereContext context)
{
    private readonly FoodSphereContext _context = context;

    public async Task<List<Food>> Gets()
    {
        return await _context.Foods.ToListAsync();
    }

    public async Task<Food?> Get(long id)
    {
        return await _context.Foods.FindAsync(id);
    }

    public async Task Update(Food food)
    {
        _context.Entry(food).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Add(Food food, List<FoodIngredientBody> ingredients)
    {
        _context.Foods.Add(food);

        foreach (var i in ingredients)
        {
            var item = new FoodIngredient
            {
                FoodId = food.Id,
                IngredientId = i.IngredientId,
                Amount = i.Amount
            };

            _context.FoodIngredients.Add(item);
        }

        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var food = await _context.Foods.FindAsync(id);

        if (food == null) return;

        await Remove(food);
    }

    public async Task Remove(Food food)
    {
        _context.Foods.Remove(food);
        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.Foods.Any(e => e.Id == id);
    }
}