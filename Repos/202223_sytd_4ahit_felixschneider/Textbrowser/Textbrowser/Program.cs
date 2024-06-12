using System;
using System.Net;
using System.Net.Sockets;

namespace Textbrowser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();

                    // Eingabe der URL
                    string url = "";
                    Console.Write("URL: ");
                    url = Console.ReadLine();

                    // TcpClient verbinden
                    var tcpClient = new TcpClient();
                    tcpClient.Connect(url, 80);

                    // Streams erstellen und nutzen
                    StreamReader reader = new StreamReader(tcpClient.GetStream());
                    StreamWriter writer = new StreamWriter(tcpClient.GetStream());

                    // Schreiben
                    writer.WriteLine("GET / HTTP/1.1");
                    writer.WriteLine();
                    writer.WriteLine();
                    writer.Flush();

                    // Lesen
                    while (!reader.EndOfStream)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    Console.ReadLine();
                }
            }
        }
    }
}