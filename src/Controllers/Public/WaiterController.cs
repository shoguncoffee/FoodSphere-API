using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Body;

namespace FoodSphere.Controllers;

[Route("[controller]")]
[ApiController]
public class WaiterController(WaiterService waiterService) : ControllerBase
{
    private readonly WaiterService _waiterService = waiterService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Waiter>>> GetWaiters()
    {
        var waiters = await _waiterService.Gets();
        return Ok(waiters);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Waiter>> GetWaiter(long id)
    {
        var waiter = await _waiterService.Get(id);

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

        try
        {
            await _waiterService.Update(waiter);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_waiterService.Exists(id))
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
    public async Task<ActionResult<Waiter>> PostWaiter(Waiter waiterbody)
    {
        var waiter = new Waiter
        {
            Name = waiterbody.Name,
            RestaurantId = waiterbody.RestaurantId
        };
        await _waiterService.Add(waiter);

        return CreatedAtAction("GetWaiter", new { id = waiter.Id }, waiter);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWaiter(long id)
    {
        var waiter = await _waiterService.Get(id);
        if (waiter == null)
        {
            return NotFound();
        }

        await _waiterService.Remove(waiter);

        return NoContent();
    }
}
