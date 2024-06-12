// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Model.Entities.Todos;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PdfGenerator // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            while(true)
            {
                try
                {
                    var factory = new ConnectionFactory()
                        { HostName = "rabbitmq", UserName = "user", Password = "password" };
                    using var connection = factory.CreateConnection();
                    using var channel = connection.CreateModel();

                    channel.ExchangeDeclare(exchange: "todos", type: ExchangeType.Topic);
                    // declare a server-named queue
                    var queueName = channel.QueueDeclare().QueueName;

                    channel.QueueBind(queue: queueName,
                        exchange: "todos",
                        routingKey: "info");

                    while (true)
                    {
                        Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");

                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body.ToArray();
                            var message = Encoding.UTF8.GetString(body);
                            var routingKey = ea.RoutingKey;
                            Console.WriteLine("Call Pdf");
                            SavePdf(message);
                            Console.WriteLine($" [x] Received '{routingKey}':'{message}'");
                        };
                        channel.BasicConsume(queue: queueName,
                            autoAck: true,
                            consumer: consumer);
                        
                        Task.Delay(1_000);
                    }
                }
                catch
                {
                    Console.WriteLine("Try connection...");
                    Task.Delay(1_000);
                }
            }
        }

        private static void SavePdf(string data)
        {
            List<Todo> todos = JsonSerializer.Deserialize<List<Todo>>(data)!;
            
            Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.Background(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(20));

                        page.Header()
                            .Text("Todos")
                            .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                        page.Content()
                            .Column(column =>
                            {
                                column.Spacing(20);
                                
                                column.Item().Text("In progress:").FontColor("#F00").FontSize(24);
                                for (var index = 0; index < todos.Where(t => !t.Completed).ToList().Count; index++)
                                {
                                    var todo = todos.Where(t => !t.Completed).ToList()[index];
                                    column.Item().Row(row =>
                                    {
                                        row.Spacing(5);
                                        row.AutoItem().Text($"{index + 1}. {todo.Name}");
                                    });
                                }
                                
                                column.Item().Text("Done:").FontColor("#F00").FontSize(24);
                                for (var index = 0; index < todos.Where(t => t.Completed).ToList().Count; index++)
                                {
                                    var todo = todos.Where(t => t.Completed).ToList()[index];
                                    column.Item().Row(row =>
                                    {
                                        row.Spacing(5);
                                        row.AutoItem().Text($"{index + 1 + todos.Where(t => !t.Completed).ToList().Count}. {todo.Name}");
                                    });
                                }
                            });

                        page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Page ");
                                x.CurrentPageNumber();
                            });
                    });
                })
                .GeneratePdf("../data/todo_report.pdf");

            Console.WriteLine("PDF Generation finished!");
        }
    }
}