using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG
{
	public class Player
	{
		private Vector2 position;
		private Texture2D texture;
		private Rectangle box;
		public Camera PlayerCamera { get; set; }
		private float rotation = 0;
		private Vector2 spriteOrigin;

		public void Initialize(Texture2D PlayerTexture, Vector2 PlayerPosition, Viewport view)
		{
			PlayerCamera = new Camera();
			position = PlayerPosition;
			texture = PlayerTexture;
			box = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
		}

		public void Update(GameTime gameTime)
		{
			box = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
			spriteOrigin = new Vector2(box.Width / 2, box.Height / 2);
			PlayerCamera.Update(gameTime, (int)position.X - 400, (int)position.Y - 200);
		}

		public Vector2 Position()
		{
			return position;
		}

		public void Move(Vector2 move)
		{
			position += move;
		}

		public void Rotate(float rotation)
		{
			this.rotation = rotation;
		}

		public Matrix GetCameraMatrix()
		{
			return PlayerCamera.transformMatrix;
		}

		public void Draw(SpriteBatch spriteBatch)

		{
			spriteBatch.Draw(texture, position, null, Color.White, rotation + (float)(Math.PI * 0.5f), spriteOrigin, 1f, SpriteEffects.None, 0);
		}

	}
}