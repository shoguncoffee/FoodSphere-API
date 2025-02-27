namespace FoodSphere.Models;

public class Food
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Price { get; set; }
    public List<IngredientItem> Items { get; } = [];
}

public class Ingredient
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Stock { get; set; }
    public List<IngredientItem> Items { get; } = [];
}


public class IngredientItem
{
    public int Id { get; set; }
    public int FoodId { get; set; }
    public required Food Food { get; set; }
    public int IngredientId { get; set; }
    public required Ingredient Ingredient { get; set; }
    public int Amount { get; set; }
}