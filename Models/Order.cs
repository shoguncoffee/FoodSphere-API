namespace FoodSphere.Models;

public class Order
{
    public long Id { get; set; }

    public DateTime DateTime { get; set; }

    public long TableId { get; set; }

    public Table Table { get; set; } = null!;

    public List<SubOrder> SubOrders { get; } = [];
}

public class SubOrder
{
    public long Id { get; set; }

    public long OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public List<OrderItem> Items { get; } = [];
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