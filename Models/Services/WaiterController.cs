using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Body;

namespace FoodSphere.Services;

public class WaiterService(FoodSphereContext context)
{
    private readonly FoodSphereContext _context = context;

    public async Task<IEnumerable<Waiter>> Gets()
    {
        return await _context.Waiters.ToListAsync();
    }

    public async Task<Waiter?> Get(long id)
    {
        return await _context.Waiters.FindAsync(id);
    }

    public async Task Update(Waiter waiter)
    {
        _context.Entry(waiter).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Add(Waiter waiter)
    {
        _context.Waiters.Add(waiter);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var waiter = await _context.Waiters.FindAsync(id);

        if (waiter == null) return;

        await Remove(waiter);
    }

    public async Task Remove(Waiter waiter)
    {
        _context.Waiters.Remove(waiter);
        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.Waiters.Any(e => e.Id == id);
    }
}