using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;



// *************************************************************
// <<<<<<< Realised the Proxy pattern on the client side >>>>>>>
// *************************************************************



namespace ChatApp2;

public interface ISendReceive
{
	public Task SendMsg(string name);
}

public class Client : ISendReceive
{
	public async Task SendMsg(string name)
	{
		Console.WriteLine("The client is up and ready.");
		IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
		UdpClient client = new UdpClient();
		while(true)
		{
			Console.WriteLine("Enter the message (or \"Exit\" word to exit)");
			string text = Console.ReadLine();

			Message msg = new Message(name, text);
			string msgJ = msg.ToJson();
			byte[] bytes= Encoding.UTF8.GetBytes(msgJ);
			await client.SendAsync(bytes,bytes.Length,endPoint);

			if (text.ToLower() == "exit")
				break;

			byte[] bytesR = client.Receive(ref endPoint);
			string msgRJ=Encoding.UTF8.GetString(bytesR);
			Message msgR=Message.FromJson(msgRJ);
			Console.WriteLine(msgR.ToString());
		}
	}
}

public class Proxy : ISendReceive
{
	private Client client;

	public Proxy()
	{
		client=new Client();
	}

	public async Task SendMsg(string name)
	{
		client.SendMsg(name);
	}
}
