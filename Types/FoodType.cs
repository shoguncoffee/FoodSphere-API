namespace FoodSphere.Types;

public class FoodBody
{
    public required string Name { get; set; }
    public int Price { get; set; }
    public List<FoodIngredientBody> Items { get; set; } = [];
}

public class FoodIngredientBody
{
    public long IngredientId { get; set; }
    public int Amount { get; set; }
}

public class IngredientBody
{
    public long IngredientId { get; set; }
    public int Amount { get; set; }
}