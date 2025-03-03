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

    public async Task Add(Food food)
    {
        _context.Foods.Add(food);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateIngredient(Food food, IngredientInfo ingredient, int amount)
    {
        if (amount < 0) return;

        var item = await _context.FoodIngredients
            .Where(i => i.FoodId == food.Id && i.IngredientId == ingredient.Id)
            .FirstOrDefaultAsync();

        if (item == null)
        {
            if (amount == 0)
            {
                return;
            }
            else
            {
                item = new FoodIngredient
                {
                    FoodId = food.Id,
                    IngredientId = ingredient.Id,
                    Amount = amount
                };

                _context.FoodIngredients.Add(item);
            }
        }
        else
        {
            if (amount == 0)
            {
                _context.FoodIngredients.Remove(item);
            }
            else
            {
                item.Amount = amount;
                _context.Entry(item).State = EntityState.Modified;
            }
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
        _context.FoodIngredients.RemoveRange(food.Items);
        _context.Foods.Remove(food);

        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.Foods.Any(e => e.Id == id);
    }
}