using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG
{
	class Player : IEntity
	{
		public Vector2 Position { get; set; }
		private Texture2D texture;
		public Circle Box { get; set; }
		public Camera PlayerCamera { get; set; }
		private float rotation = 0;
		private Vector2 spriteOrigin;

		public void Initialize(Vector2 PlayerPosition)
		{
			PlayerCamera = new Camera(PlayerPosition);
			Position = PlayerPosition;
			texture = TextureLoader.Player;
			Box = new Circle(Position, texture.Height / 2);
		}

		public Vector2 Size()
		{
			return new Vector2(texture.Width, texture.Height);
		}

		public void Update(GameTime gameTime)
		{
			Console.WriteLine(Position);
			Box.Center = Position;
			spriteOrigin = new Vector2(Box.Radius, Box.Radius);
			PlayerCamera.Update(gameTime, (int)Position.X, (int)Position.Y);
		}

		public void Move(Vector2 move)
		{
			Position += move;
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
			spriteBatch.Draw(texture, Position, null, Color.White, rotation + (float)(Math.PI * 0.5f), spriteOrigin, 1f, SpriteEffects.None, 0);
		}

	}
}