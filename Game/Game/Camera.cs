using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG
{
	public class Camera
	{
		public Matrix transformMatrix;
		public Vector2 Position { get; set; }

		public void Update(GameTime gameTime, int X, int Y)
		{
			float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
			Position = new Vector2(Position.X + (X - Position.X) * 5 * delta, Position.Y + (Y - Position.Y) * 5 * delta);
			transformMatrix = Matrix.CreateScale(new Vector3(1, 1, 0)) *
				Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0));
		}


	}
}