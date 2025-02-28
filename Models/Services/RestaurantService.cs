using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Body;

namespace FoodSphere.Services;

public class RestaurantService(FoodSphereContext context)
{
    private readonly FoodSphereContext _context = context;

    public async Task<IEnumerable<Restaurant>> Gets()
    {
        return await _context.Restaurants.ToListAsync();
    }

    public async Task<Restaurant?> Get(long id)
    {
        return await _context.Restaurants.FindAsync(id);
    }

    public async Task Update(Restaurant restaurant)
    {
        _context.Entry(restaurant).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Add(Restaurant restaurant)
    {
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);

        if (restaurant == null) return;

        await Remove(restaurant);
    }

    public async Task Remove(Restaurant restaurant)
    {
        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.Restaurants.Any(e => e.Id == id);
    }
}