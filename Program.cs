namespace ChatApp2;

internal class Program
{
	static async Task Main(string[] args)
	{
		if (args.Length == 0)
		{
			await Server.Instance.AcceptMsg();
			Console.WriteLine("Exiting the server");
		}
		else if (args.Length == 1)
		{
			Proxy proxy = new Proxy();
			await proxy.SendMsg(args[0]);
			// await Client.SendMsg(args[0]);
			Console.WriteLine("Exiting the client");
		}
	}
}
