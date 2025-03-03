using FoodSphere.Models;

namespace FoodSphere.Body;

public class FoodRequest
{
    public required string Name { get; set; }

    public int Price { get; set; }

    public List<FoodIngredientBody> Items { get; set; } = [];
}

public class FoodResponse
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public int Price { get; set; }

    public List<FoodIngredientBody> Items { get; set; } = [];

    public static FoodResponse From(Food food)
    {
        return new FoodResponse
        {
            Id = food.Id,
            Name = food.Name,
            Price = food.Price,
            Items = [.. food.Items.Select(FoodIngredientBody.From)],
        };
    }
}

public class FoodIngredientBody
{
    public long IngredientId { get; set; }

    public int Amount { get; set; }

    public static FoodIngredientBody From(FoodIngredient ingredient)
    {
        return new FoodIngredientBody
        {
            IngredientId = ingredient.IngredientId,
            Amount = ingredient.Amount,
        };
    }
}

public class IngredientRequest
{
    public required string Name { get; set; }

    public int Stock { get; set; }
}

public class IngredientResponse
{
    public required string Name { get; set; }

    public int Stock { get; set; }

    public static IngredientResponse From(IngredientInfo ingredient)
    {
        return new IngredientResponse
        {
            Name = ingredient.Name,
            Stock = ingredient.Stock,
        };
    }
}