using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MG
{
	public class Map
	{
		Rectangle mapBox;
		Texture2D texture;
		List<Player> players = new List<Player>();

		public void AddPlayer(Player newPlayer)
		{
			players.Add(newPlayer);
		}

		public void LoadContent(Texture2D mapTexture)
		{
			texture = mapTexture;
		}
		public void Initialize(Vector2 mapSize)
		{
			mapBox = new Rectangle(0, 0, (int)mapSize.X, (int)mapSize.Y);
		}

		public void Update()
		{

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Vector2(0, 0), null, Color.White);
		}
	}
}
