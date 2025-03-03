using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Body;

namespace FoodSphere.Services;

public class SubOrderService(FoodSphereContext context)
{
    private readonly FoodSphereContext _context = context;

    public async Task<List<SubOrder>> Gets()
    {
        return await _context.SubOrders.ToListAsync();
    }

    public async Task<SubOrder?> Get(long id)
    {
        return await _context.SubOrders.FindAsync(id);
    }

    public async Task Update(SubOrder subOrder)
    {
        _context.Entry(subOrder).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateItem(SubOrder subOrder, Food food, int quantity)
    {
        // if (subOrder.Status != SubOrderStatus.Wait) return;

        if (quantity < 0) return;

        var item = await _context.OrderItems
            .Where(i => i.SubOrderId == subOrder.Id && i.FoodId == food.Id)
            .FirstOrDefaultAsync();

        if (item == null)
        {
            if (quantity == 0)
            {
                return;
            }
            else
            {
                item = new OrderItem
                {
                    SubOrderId = subOrder.Id,
                    FoodId = food.Id,
                    Quantity = quantity
                };

                _context.OrderItems.Add(item);
            }
        }
        else
        {
            if (quantity == 0)
            {
                _context.OrderItems.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task Add(SubOrder subOrder)
    {
        _context.SubOrders.Add(subOrder);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var subOrder = await _context.SubOrders.FindAsync(id);

        if (subOrder == null) return;

        await Remove(subOrder);
    }

    public async Task Remove(SubOrder subOrder)
    {
        _context.OrderItems.RemoveRange(subOrder.Items);
        _context.SubOrders.Remove(subOrder);

        await _context.SaveChangesAsync();
    }

    public bool Exists(long id)
    {
        return _context.SubOrders.Any(e => e.Id == id);
    }
}