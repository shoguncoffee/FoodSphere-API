using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;
using FoodSphere.Body;

namespace FoodSphere.Controllers;

[Route("[controller]")]
[ApiController]
public class OrderController(OrderService orderService) : ControllerBase
{
    private readonly OrderService _orderService = orderService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders()
    {
        var orders = await _orderService.Gets();
        return Ok(orders.Select(OrderResponse.From));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponse>> GetOrder(long id)
    {
        var order = await _orderService.Get(id);

        if (order == null)
        {
            return NotFound();
        }

        return OrderResponse.From(order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrder(long id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        try
        {
            await _orderService.Update(order);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_orderService.Exists(id))
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
    public async Task<ActionResult<OrderResponse>> PostOrder(OrderRequest orderbody)
    {
        var order = new Order
        {
            DateTime = DateTime.Now,
            TableId = orderbody.TableId
        };

        await _orderService.Add(order);

        return CreatedAtAction("GetOrder", new { id = order.Id }, order);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(long id)
    {
        var order = await _orderService.Get(id);
        if (order == null)
        {
            return NotFound();
        }

        await _orderService.Remove(order);

        return NoContent();
    }
}
