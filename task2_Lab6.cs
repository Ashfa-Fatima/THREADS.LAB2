using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPClient

{
    static void Main()
    {
        UdpClient client = new UdpClient();
        client.Connect("192.168.18.39", 9000);

        Console.WriteLine("Enter your integer value(client side");
        int clientValue = int.Parse(Console.ReadLine());

        byte[]data =
        Encoding.ASCII.GetBytes(clientValue.ToString());
        client.Send(data,data.Length);

        IPEndPoint serverEP = new IPEndPoint(IPAddress.Any, 0);

        byte[] receiveData = client.Receive(ref serverEP);
        string result = Encoding.ASCII.GetString(receiveData);

        Console.WriteLine($" Sum recived from server:{result}");
        client.Close();
    }
}
