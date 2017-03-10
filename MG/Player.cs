using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG
{
	public class Player
	{
		public Vector2 Position;
		public Texture2D Texture;
		public Rectangle box;
		public Camera camera = new Camera();

		public void Initialize(Texture2D PlayerTexture, Vector2 PlayerPosition, Viewport view)
		{
			Position = PlayerPosition;
			Texture = PlayerTexture;
			box = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
		}

		public void Update(GameTime gameTime)
		{
			box.X = (int)Position.X;
			box.Y = (int)Position.Y;
			camera.Update(gameTime, box.X - 240, box.Y - 120);
		}



		public void Draw(SpriteBatch spriteBatch)

		{
			spriteBatch.Draw(Texture, Position, null, Color.White);
		}

	}
}
