using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG
{
	public class Camera
	{
		public Matrix transformMatrix;
		Vector2 position;

		public void Update(GameTime gameTime, int X, int Y)
		{
			float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
			position = new Vector2(position.X + (X - position.X) * 5 * delta, position.Y + (Y - position.Y) * 5 * delta);
			transformMatrix = Matrix.CreateScale(new Vector3(1, 1, 0)) *
				Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0));
		}


	}
}
