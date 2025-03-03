using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Body;

namespace FoodSphere.Services;

public class BranchService(FoodSphereContext context, TableService tableService, IngredientStockService ingredientStockService, WaiterService waiterService)
{
    private readonly FoodSphereContext _context = context;
    private readonly TableService _tableService = tableService;
    private readonly IngredientStockService _ingredientStockService = ingredientStockService;
    private readonly WaiterService _waiterService = waiterService;

    public async Task<List<Branch>> Gets()
    {
        return await _context.Branches.ToListAsync();
    }

    public async Task<Branch?> Get(long id)
    {
        return await _context.Branches.FindAsync(id);
    }

    public async Task Update(Branch branch)
    {
        _context.Entry(branch).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Add(Branch branch)
    {
        _context.Branches.Add(branch);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var branch = await _context.Branches.FindAsync(id);

        if (branch == null) return;

        await Remove(branch);
    }

    public async Task Remove(Branch branch)
    {
        foreach (var table in branch.Tables)
        {
            await _tableService.Remove(table);
        }
        foreach (var ingredientStock in branch.IngredientStocks)
        {
            await _ingredientStockService.Remove(ingredientStock);
        }
        foreach (var waiter in branch.Waiters)
        {
            await _waiterService.Remove(waiter);
        }

        _context.Branches.Remove(branch);

        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.Branches.Any(e => e.Id == id);
    }
}