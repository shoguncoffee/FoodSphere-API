using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSphere.Models
{
    public class Restaurant
    {
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        public List<Branch> Branches { get; } = [];

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }
    }

    public class Branch
    {
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;

        public List<IngredientStock> IngredientStocks { get; } = [];

        public List<Table> Tables { get; } = [];

        public List<Waiter> Waiters { get; } = [];

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

    }

    public class Waiter
    {
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        public long BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public required string Name { get; set; }

        public WaiterStatus Status { get; set; }
    }

    public class Table
    {
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        public long BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public required string Name { get; set; }

        public int Capacity { get; set; }

        public TableStatus Status { get; set; }
    }
}

public enum WaiterStatus
{
    Pending,
    Cooking,
    Done,
    Cancelled
}

public enum TableStatus
{
    Pending,
    Cooking,
    Done,
    Cancelled
}