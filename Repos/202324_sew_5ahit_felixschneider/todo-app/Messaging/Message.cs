using System.Text;
using System.Text.Json;
using Model.Entities.Todos;
using RabbitMQ.Client;

namespace Messaging;

public class Message
{
    private ConnectionFactory Factory { get; set; }
    private string Hostname { get; set; }

    public Message()
    {
        Hostname = "localhost";
        Factory = new ConnectionFactory() { HostName = Hostname, UserName = "user", Password = "password"};
    }
    
    public async Task GenerateReport(List<Todo> todos)
    {
        using var connection = Factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.ExchangeDeclare(exchange: "todos", type: ExchangeType.Topic);

        var severity = "info";
        var message = JsonSerializer.Serialize(todos);
        var body = Encoding.UTF8.GetBytes(message);
        
        channel.BasicPublish(
            exchange: "todos",
            routingKey: severity,
            basicProperties: null,
            body: body);
        
        Console.WriteLine($" [x] Sent '{severity}':'{message}'");
    }
}