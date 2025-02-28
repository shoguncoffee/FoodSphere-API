using FoodSphere.Models;

namespace FoodSphere.Body;

public class OrderRequest
{
    public long TableId { get; set; }
}

public class OrderResponse
{
    public long Id { get; set; }

    public DateTime DateTime { get; set; }

    public TableResponse Table { get; set; } = null!;

    public List<SubOrderResponse> SubOrders { get; set; } = [];

    public static OrderResponse From(Order order)
    {
        return new OrderResponse
        {
            Id = order.Id,
            DateTime = order.DateTime,
            Table = TableResponse.From(order.Table),
            SubOrders = [.. order.SubOrders.Select(SubOrderResponse.From)],
        };
    }
}

public class OrderItemBody
{
    public long SubOrderId { get; set; }

    public long FoodId { get; set; }

    public int Quantity { get; set; }

    public string? Note { get; set; }

    public static OrderItemBody From(OrderItem orderItem)
    {
        return new OrderItemBody
        {
            SubOrderId = orderItem.SubOrderId,
            FoodId = orderItem.FoodId,
            Quantity = orderItem.Quantity,
            Note = orderItem.Note,
        };
    }
}

public class SubOrderRequest
{
    public long OrderId { get; set; }

    public List<OrderItemBody> Items { get; set; } = [];
}

public class SubOrderResponse
{
    public long Id { get; set; }

    public long OrderId { get; set; }

    public DateTime DateTime { get; set; }

    public List<OrderItemBody> Items { get; set; } = [];

    public static SubOrderResponse From(SubOrder subOrder)
    {
        return new SubOrderResponse
        {
            Id = subOrder.Id,
            OrderId = subOrder.OrderId,
            DateTime = subOrder.DateTime,
            Items = [.. subOrder.Items.Select(OrderItemBody.From)],
        };
    }
}