using Microsoft.EntityFrameworkCore;

namespace Food.Models;

public class FoodContext(DbContextOptions<FoodContext> options) : DbContext(options)
{
    public DbSet<FoodItem> FoodItems { get; set; } = null!;
}