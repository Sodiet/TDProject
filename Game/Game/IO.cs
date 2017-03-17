using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MG
{
	class IO
	{
		Player player;
		private Vector2 distance;
		Circle phantomBox;
		Vector2 phantomMotion;

		public IO(Player newPlayer)
		{
			player = newPlayer;
		}

		public void Update(KeyboardState keyboardState, MouseState mouseState, GameTime gameTime)
		{
			distance = mouseState.Position.ToVector2() + player.PlayerCamera.Position - player.Position;

			player.Rotate((float)Math.Atan2(distance.Y, distance.X));
			Console.WriteLine(mouseState.Position.ToVector2() + player.PlayerCamera.Position);


			if (keyboardState.IsKeyDown(Keys.Up))
			{
				Vector2 motion = new Vector2(0, -1);
				phantomMotion = player.Position + motion;
				phantomBox = new Circle(phantomMotion, player.Box.Radius);
				if (!CollisionComtroller.CheckCollision(phantomBox))
				{
					motion *= (gameTime.ElapsedGameTime.Seconds + 1);
					player.Move(motion);
				}

			}

			if (keyboardState.IsKeyDown(Keys.Down))
			{
				Vector2 motion = new Vector2(0, 1);
				phantomMotion = player.Position + motion;

				phantomBox = new Circle(phantomMotion, player.Box.Radius);
				if (!CollisionComtroller.CheckCollision(phantomBox))
				{
					motion *= (gameTime.ElapsedGameTime.Seconds + 1);
					player.Move(motion);
				}
			}

			if (keyboardState.IsKeyDown(Keys.Left))
			{
				Vector2 motion = new Vector2(-1, 0);
				phantomMotion = player.Position + motion;
				phantomBox = new Circle(phantomMotion, player.Box.Radius);
				if (!CollisionComtroller.CheckCollision(phantomBox))
				{
					motion *= (gameTime.ElapsedGameTime.Seconds + 1);
					player.Move(motion);
				}
			}

			if (keyboardState.IsKeyDown(Keys.Right))
			{
				Vector2 motion = new Vector2(1, 0);
				phantomMotion = player.Position + motion;
				phantomBox = new Circle(phantomMotion, player.Box.Radius);
				if (!CollisionComtroller.CheckCollision(phantomBox))
				{
					motion *= (gameTime.ElapsedGameTime.Seconds + 1);
					player.Move(motion);
				}
			}

		}
	}
}