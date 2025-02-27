namespace FoodSphere.Models;

public class Restaurant
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public List<Table> Tables { get; } = [];
    public List<Waiter> Waiters { get; } = [];
}

public class Waiter
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public required Restaurant Restaurant { get; set; }
    public required string Name { get; set; }
}


public class Table
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public required Restaurant Restaurant { get; set; }
    public required string Name { get; set; }
    public int Seat { get; set; }
}
