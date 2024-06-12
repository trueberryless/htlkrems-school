using System.Collections.Generic;

namespace OrderProcess;

public class Shipment
{
    public Order Order { get; set; }
    public List<OrderItem> Items { get; set; }
    public int? TotalPrice { get; set; }
    public int ItemCount { get; set; }
}