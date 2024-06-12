using System;
using Azure;

namespace OrderProcess;

public class OrderTable : Azure.Data.Tables.ITableEntity
{
    public double OrderTime { get; set; }
    public string ShipmentTimes { get; set; }
    public string ShipmentCosts { get; set; }
    public string ItemCount { get; set; }
    
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}