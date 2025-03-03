using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSphere.Models
{
    public class Food
    {
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        // may separate for each branch?
        public List<FoodIngredient> Items { get; } = [];

        public required string Name { get; set; }

        public string? ImageUrl { get; set; }

        // may separate for each branch?
        public int Price { get; set; }
    }

    public class IngredientInfo
    {
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;

        public List<FoodIngredient> Items { get; } = [];

        public required string Name { get; set; }

        public string? ImageUrl { get; set; }
    }

    public class IngredientStock
    {
        public long Id { get; set; }

        public long IngredientId { get; set; }
        public IngredientInfo Ingredient { get; set; } = null!;

        public long BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public int Stock { get; set; }
    }

    public class FoodIngredient
    {
        public long Id { get; set; }

        public long FoodId { get; set; }
        public Food Food { get; set; } = null!;

        public long IngredientId { get; set; }
        public IngredientInfo Ingredient { get; set; } = null!;

        public int Amount { get; set; }
    }
}