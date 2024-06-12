using System.Collections.Generic;

namespace OrderProcess;

public class Order
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    
    public int? TotalPrice { get; set; }
    
    public List<OrderItem> OrderItems { get; set; }
}

public class OrderItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    
    public int? Price { get; set; }
}