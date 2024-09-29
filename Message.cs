using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatApp2
{
	internal class Message
	{
		public string Name { get; set; }
		public string Text { get; set; }
		public DateTime Date { get; set; }

		public Message(string name, string text)
		{
			Name = name;
			Text = text;
			Date=DateTime.Now;
		}
		public string ToJson()
		{
			return JsonSerializer.Serialize(this);
		}

		public static Message? FromJson(string jsonData)
		{
			return JsonSerializer.Deserialize<Message>(jsonData);
		}

		public override string ToString()
		{
			return String.Format($"{Date.ToString()} - {Name}:{Text}");
		}
	}
}
