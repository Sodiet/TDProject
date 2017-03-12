using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace MG
{
	static class TextureLoader
	{
		public static Texture2D Player { get; private set; }
		public static Texture2D Background { get; private set; }

		public static void LoadContent(ContentManager content)
		{
			Background = content.Load<Texture2D>("background");
			Player = content.Load<Texture2D>("player");
		}

	}
}
