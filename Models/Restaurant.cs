namespace FoodSphere.Models;

public class Restaurant
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; }

    public List<Table> Tables { get; } = [];

    public List<Waiter> Waiters { get; } = [];
}

public class Waiter
{
    public long Id { get; set; }

    public long RestaurantId { get; set; }

    public Restaurant Restaurant { get; set; } = null!;

    public required string Name { get; set; }
}


public class Table
{
    public long Id { get; set; }

    public long RestaurantId { get; set; }

    public Restaurant Restaurant { get; set; } = null!;

    public required string Name { get; set; }

    public int Seat { get; set; }
}
