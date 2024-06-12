using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrderProcess;

public static class EmailService
{
    public static void SendMail(string recipientEmail, string subject, string body)
    {
        // Hehe, you don't get my brevo password... xd
        string jsonFilePath = Path.Combine(Environment.CurrentDirectory, "local.settings.json");
        if (File.Exists(jsonFilePath))
        {
            string jsonContents = File.ReadAllText(jsonFilePath);
            JObject settings = JObject.Parse(jsonContents);

            // Retrieve a value from local.settings.json
            string networkCredentialPassword = settings["Values"]?["NetworkCredentialPassword"]?.ToString();

            if (!string.IsNullOrEmpty(networkCredentialPassword))
            {
                try
                {
                    // Create a new SmtpClient instance
                    SmtpClient smtpClient = new SmtpClient("smtp-relay.sendinblue.com")
                    {
                        Port = 587, // Brevo SMTP port (587 is commonly used for TLS)
                        Credentials = new NetworkCredential("trueberryless+brevo@gmail.com", networkCredentialPassword),
                        EnableSsl = true, // Use SSL/TLS for secure communication
                    };

                    // Create a new MailMessage instance
                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("trueberryless+brevo@gmail.com"),
                        Subject = subject,
                        Body = body,
                    };

                    // Add recipients
                    mailMessage.To.Add(recipientEmail);

                    // Send the email
                    smtpClient.Send(mailMessage);

                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }

    [FunctionName("SendConfirmationMail")]
    public static async Task SendConfirmationMail([ActivityTrigger] Order order, ILogger log)
    {
        log.LogInformation($"Sending confirmation mail.");

        var emailContent = $"""
                                Sehr geehrte/r Herr/Frau {order.Name}!
                                
                                Ihre Bestellung wurde soeben erfolgreich aufgenommen und wird demnächst weiterverarbeitet!
                                
                                Hier noch einmal Ihre Bestellung:
                                
                                {String.Join("\n", order.OrderItems.Select(i =>
                                    $"{i.Quantity}x {i.Name} um {i.Price} €"))}
                                
                                Mit freundlichen Grüßen
                                Amazon
                            """;

        // send email with brevo
        SendMail(order.Email, "OrderProcess: Confirmation mail!", emailContent);
    }

    [FunctionName("SendOrderExecutedMail")]
    public static async Task SendOrderExecutedMail([ActivityTrigger] List<Shipment> shipments, ILogger log)
    {
        log.LogInformation($"Sending confirmation mail: {JsonConvert.SerializeObject(shipments, Formatting.Indented)}");

        var emailContent = $"""
                                Folgende Bestellungen wurden an die Adresse {shipments.First(s => s.Order.Address != "").Order.Address} zugestellt:
                                
                                {String.Join("\n", shipments.Select(s =>
                                    String.Join(", ", s.Items.Select(i =>
                                        $"{i.Quantity}x {i.Name} um {i.Price} €"))))}
                            """;

        // send email with brevo
        SendMail(shipments.First(s => s.Order != null).Order.Email, "OrderProcess: Order completed!", emailContent);
    }
}