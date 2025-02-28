namespace FoodSphere.Models;

public class Food
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public int Price { get; set; }

    public List<FoodIngredient> Items { get; } = [];
}

public class Ingredient
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public int Stock { get; set; }

    public List<FoodIngredient> Items { get; } = [];
}


public class FoodIngredient
{
    public long Id { get; set; }

    public long FoodId { get; set; }

    public Food Food { get; set; } = null!;

    public long IngredientId { get; set; }

    public Ingredient Ingredient { get; set; } = null!;

    public int Amount { get; set; }
}