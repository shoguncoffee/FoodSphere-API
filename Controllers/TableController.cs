using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;

namespace FoodSphere.Controllers;

[Route("[controller]")]
[ApiController]
public class TableController(TableService tableService) : ControllerBase
{
    private readonly TableService _tableService = tableService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Table>>> GetTables()
    {
        var tables = await _tableService.Gets();
        return Ok(tables);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Table>> GetTable(long id)
    {
        var table = await _tableService.Get(id);

        if (table == null)
        {
            return NotFound();
        }

        return table;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTable(long id, Table table)
    {
        if (id != table.Id)
        {
            return BadRequest();
        }

        try
        {
            await _tableService.Update(table);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_tableService.Exists(id))
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
    public async Task<ActionResult<Table>> PostTable(Table tablebody)
    {
        var table = new Table
        {
            Name = tablebody.Name,
            Seat = tablebody.Seat
        };
        await _tableService.Add(table);

        return CreatedAtAction("GetTable", new { id = table.Id }, table);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTable(long id)
    {
        var table = await _tableService.Get(id);
        if (table == null)
        {
            return NotFound();
        }

        await _tableService.Remove(table);

        return NoContent();
    }
}