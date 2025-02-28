using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;

namespace FoodSphere.Controllers;

[Route("[controller]")]
[ApiController]
public class TableController(FoodSphereContext context) : ControllerBase
{
    private readonly FoodSphereContext _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Table>>> GetTable()
    {
        return await _context.Tables.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Table>> GetTable(long id)
    {
        var table = await _context.Tables.FindAsync(id);

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

        _context.Entry(table).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TableExists(id))
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
    public async Task<ActionResult<Table>> PostTable(Table table)
    {
        _context.Tables.Add(table);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTable", new { id = table.Id }, table);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTable(long id)
    {
        var table = await _context.Tables.FindAsync(id);
        if (table == null)
        {
            return NotFound();
        }

        _context.Tables.Remove(table);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TableExists(long id)
    {
        return _context.Tables.Any(e => e.Id == id);
    }
}