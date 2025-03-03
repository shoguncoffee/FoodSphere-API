using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Body;

namespace FoodSphere.Services;

public class TableService(FoodSphereContext context)
{
    private readonly FoodSphereContext _context = context;

    public async Task<List<Table>> Gets()
    {
        return await _context.Tables.ToListAsync();
    }

    public async Task<Table?> Get(long id)
    {
        return await _context.Tables.FindAsync(id);
    }

    public async Task Update(Table table)
    {
        _context.Entry(table).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Add(Table table)
    {
        _context.Tables.Add(table);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var table = await _context.Tables.FindAsync(id);

        if (table == null) return;

        await Remove(table);
    }

    public async Task Remove(Table table)
    {
        _context.Tables.Remove(table);
        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.Tables.Any(e => e.Id == id);
    }
}