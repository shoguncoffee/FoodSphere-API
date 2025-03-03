using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Body;

namespace FoodSphere.Controllers;

[Route("[controller]")]
[ApiController]
public class SubOrderController(SubOrderService subOrderService) : ControllerBase
{
    private readonly SubOrderService _subOrderService = subOrderService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubOrder>>> GetSubOrders()
    {
        var subOrders = await _subOrderService.Gets();
        return Ok(subOrders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubOrder>> GetSubOrder(long id)
    {
        var subOrder = await _subOrderService.Get(id);

        if (subOrder == null)
        {
            return NotFound();
        }

        return subOrder;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSubOrder(long id, SubOrder subOrder)
    {
        if (id != subOrder.Id)
        {
            return BadRequest();
        }

        try
        {
            await _subOrderService.Update(subOrder);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_subOrderService.Exists(id))
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
    public async Task<ActionResult<SubOrder>> PostSubOrder(SubOrder subOrderbody)
    {
        var subOrder = new SubOrder
        {
            OrderId = subOrderbody.OrderId,
        };
        await _subOrderService.Add(subOrder);

        return CreatedAtAction("GetSubOrder", new { id = subOrder.Id }, subOrder);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubOrder(long id)
    {
        var subOrder = await _subOrderService.Get(id);
        if (subOrder == null)
        {
            return NotFound();
        }

        await _subOrderService.Remove(subOrder);

        return NoContent();
    }
}
