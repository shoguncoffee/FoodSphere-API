using Microsoft.EntityFrameworkCore;

namespace FoodSphere.Models;

public class FoodSphereContext(DbContextOptions<FoodSphereContext> options) : DbContext(options)
{
    public DbSet<Food> Foods { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<FoodIngredient> FoodIngredients { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<SubOrder> SubOrders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Restaurant> Restaurants { get; set; } = null!;
    public DbSet<Table> Tables { get; set; } = default!;
    public DbSet<Waiter> Waiters { get; set; } = default!;
}