using System.Net;
using System.Net.Sockets;
using System.Threading.Channels;

/*// erstelle einen neuen UDP-Socket (Dgram = Datagram = Data + Telegram)
var socket = new Socket(SocketType.Dgram, ProtocolType.Udp);

// teile dem Socket mit, auf welcher Adresse und Port gelauscht werden soll
// Loopback = nur vom lokalen Rechner entgegen nehmen / Any = Paket aus dem Netzwerk entgegen nehmen
var endpoint = new IPEndPoint(IPAddress.Loopback, 8000);
socket.Bind(endpoint);

// anlegen eines Buffer für eingehende Nachrichten
var buffer = new byte[1024];

Console.WriteLine("Warte auf eingehende Nachrichte...");

while (true)
{
    var remoteEndPoint = (EndPoint)endpoint;
    var length = socket.ReceiveFrom(buffer, ref remoteEndPoint);
    Console.WriteLine($"{length} bytes von {remoteEndPoint} empfangen: ");

    Console.WriteLine(string.Join(", ", buffer.Take(length)));
}*/


// TCP

// Server hört auf einkommende Verbindungen
var tcpListener = new TcpListener(IPAddress.Loopback, 8085);
tcpListener.Start();

var tcpClient = tcpListener.AcceptTcpClient();
var stream = tcpClient.GetStream();
// stream.ReadTimeout = 100;

/*var reader = new StreamReader(stream);
while (!reader.EndOfStream)
{
    var line = reader.ReadLine();
    Console.WriteLine(line);
}

Console.WriteLine("------------------------------------");
Console.ReadLine();*/

var writer = new StreamWriter(stream);

while (true)
{
    var line = Console.ReadLine();
    writer.WriteLine();
    writer.Flush();
}
