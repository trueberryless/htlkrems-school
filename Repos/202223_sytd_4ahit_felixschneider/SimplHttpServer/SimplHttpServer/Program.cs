using System.Net;
using System.Net.Sockets;

Console.WriteLine("Waiting for requests...");

// Server
var tcpListener = new TcpListener(IPAddress.Loopback, 80);
tcpListener.Start();

while (true)
{
    var tcpClient = tcpListener.AcceptTcpClient();
    var stream = tcpClient.GetStream();
    var reader = new StreamReader(stream);

    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        Console.WriteLine(line);
    }
}

Console.ReadLine();

// Client
// var tcpClient = new TcpClient();


// var updClient = new UdpClient(8000);
// var repsponse = await updClient.ReceiveAsync();

