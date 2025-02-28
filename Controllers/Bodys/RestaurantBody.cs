using FoodSphere.Models;

namespace FoodSphere.Body;

public class RestaurantRequest
{
    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; }
}

public class RestaurantResponse
{
    public long Id { get; set; }

    // ...

    public static RestaurantResponse From(Restaurant restaurant)
    {
        return new RestaurantResponse
        {
            Id = restaurant.Id,
        };
    }
}

public class WaiterRequest
{
    public long RestaurantId { get; set; }

    public required string Name { get; set; }
}

public class WaiterResponse
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public static WaiterResponse From(Waiter waiter)
    {
        return new WaiterResponse
        {
            Id = waiter.Id,
            Name = waiter.Name,
        };
    }
}

public class TableResquest
{
    public long RestaurantId { get; set; }

    public required string Name { get; set; }

    public int Seat { get; set; }
}

public class TableResponse
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public int Seat { get; set; }

    public static TableResponse From(Table table)
    {
        return new TableResponse
        {
            Id = table.Id,
            Name = table.Name,
            Seat = table.Seat,
        };
    }
}