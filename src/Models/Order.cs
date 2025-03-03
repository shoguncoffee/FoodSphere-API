using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSphere.Models
{
    public class Order
    {
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        public long TableId { get; set; }
        public Table Table { get; set; } = null!;

        public List<SubOrder> SubOrders { get; } = [];

        public OrderStatus Status { get; set; }
    }

    public class SubOrder
    {
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public List<OrderItem> Items { get; } = [];

        public SubOrderStatus Status { get; set; }
    }

    public class OrderItem
    {
        public long Id { get; set; }

        public long SubOrderId { get; set; }
        public SubOrder SubOrder { get; set; } = null!;

        public long FoodId { get; set; }
        public Food Food { get; set; } = null!;

        public int Quantity { get; set; }

        public string? Note { get; set; }
    }
}

public enum OrderStatus
{
    Pending,
    Processing,
    Completed,
    Canceled,
}

public enum SubOrderStatus
{
    Pending,
    Processing,
    Completed,
    Canceled,
}