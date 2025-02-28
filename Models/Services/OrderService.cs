using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Body;

namespace FoodSphere.Services;

public class OrderService(FoodSphereContext context)
{
    private readonly FoodSphereContext _context = context;

    public async Task<IEnumerable<Order>> Gets()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order?> Get(long id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task Update(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Add(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null) return;

        await Remove(order);
    }

    public async Task Remove(Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.Orders.Any(e => e.Id == id);
    }
}