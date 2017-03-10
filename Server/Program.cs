using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using Microsoft.Xna;

namespace Server
{
	class Program
	{

		static void Main(string[] args)
		{
			var config = new NetPeerConfiguration("multiplayer") { Port = 9999 };
			config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
			var server = new NetServer(config);
			server.Start();
			Console.WriteLine("Server started on port " + config.Port);
			while (true)
			{
				NetIncomingMessage incMsg;
				if ((incMsg = server.ReadMessage()) == null) continue;
				switch (incMsg.MessageType)
				{
					case NetIncomingMessageType.ConnectionApproval:
						var DataPackage = incMsg.ReadByte();
						if (DataPackage == (byte)PacketType.Connect)
						{
							var Packet = new LoginInfo();
							incMsg.ReadAllProperties(Packet);
							incMsg.SenderConnection.Approve();

							var OutputMsg = server.CreateMessage();
							OutputMsg.WriteAllProperties((byte)PacketType.Connect);
							OutputMsg.WriteAllProperties(true);
							server.SendMessage(OutputMsg, incMsg.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
						}
						break;


				}
			}
		}

	}
}