using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;

namespace FoodSphere.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WaiterController : ControllerBase
{
    private readonly FoodSphereContext _context;

    public WaiterController(FoodSphereContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Waiter>>> GetWaiter()
    {
        return await _context.Waiters.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Waiter>> GetWaiter(long id)
    {
        var waiter = await _context.Waiters.FindAsync(id);

        if (waiter == null)
        {
            return NotFound();
        }

        return waiter;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWaiter(long id, Waiter waiter)
    {
        if (id != waiter.Id)
        {
            return BadRequest();
        }

        _context.Entry(waiter).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WaiterExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Waiter>> PostWaiter(Waiter waiter)
    {
        _context.Waiters.Add(waiter);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetWaiter", new { id = waiter.Id }, waiter);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWaiter(long id)
    {
        var waiter = await _context.Waiters.FindAsync(id);
        if (waiter == null)
        {
            return NotFound();
        }

        _context.Waiters.Remove(waiter);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WaiterExists(long id)
    {
        return _context.Waiters.Any(e => e.Id == id);
    }
}
