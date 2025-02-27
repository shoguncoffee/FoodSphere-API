namespace FoodSphere.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public required Table Table { get; set; }
    public List<SubOrder> SubOrders { get; } = [];
}

public class SubOrder
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public required Order Order { get; set; }
    public DateTime DateTime { get; set; }
    public List<OrderItem> Items { get; } = [];
}

public class OrderItem
{
    public int Id { get; set; }
    public int SubOrderId { get; set; }
    public required SubOrder SubOrder { get; set; }
    public int FoodId { get; set; }
    public required Food Food { get; set; }
    public int Quantity { get; set; }
    public string? Note { get; set; }
}