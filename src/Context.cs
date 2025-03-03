using Microsoft.EntityFrameworkCore;

namespace FoodSphere.Models;

public class FoodSphereContext(DbContextOptions<FoodSphereContext> options) : DbContext(options)
{
    public DbSet<Food> Foods { get; set; } = default!;
    public DbSet<IngredientInfo> IngredientInfos { get; set; } = default!;
    public DbSet<IngredientStock> IngredientStocks { get; set; } = default!;
    public DbSet<FoodIngredient> FoodIngredients { get; set; } = default!;
    public DbSet<Order> Orders { get; set; } = default!;
    public DbSet<SubOrder> SubOrders { get; set; } = default!;
    public DbSet<OrderItem> OrderItems { get; set; } = default!;
    public DbSet<Restaurant> Restaurants { get; set; } = default!;
    public DbSet<Branch> Branches { get; set; } = default!;
    public DbSet<Table> Tables { get; set; } = default!;
    public DbSet<Waiter> Waiters { get; set; } = default!;
}