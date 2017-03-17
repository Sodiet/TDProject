using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MG
{
	static class CollisionComtroller
	{
		static List<IEntity> entities = new List<IEntity>();
		static List<IEntity> players = new List<IEntity>();
		static List<Building> buildings = new List<Building>();


		public static void Add(IEntity newEntity)
		{
			switch (newEntity.GetType().ToString())
			{
				case "MG.Player":
					entities.Add(newEntity);
					players.Add(newEntity);
					break;
				case "MG.Building":
					entities.Add(newEntity);
					buildings.Add((Building)newEntity);
					break;
			}
		}

		public static bool CheckCollision(Circle box)
		{
			
			for (int j = 0; j < buildings.Count; j++)
			{
				if (CircleRecatangleCollision(box, buildings.ToArray()[j].Box))
				{
					return true;
				}
			}
			return false;
		}

		public static bool RectangleRectangleCollision(Rectangle box1, Rectangle box2)
		{
			if (box1.Bottom >= box2.Top)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool CircleCircleCollision(Circle circle1, Circle circle2)
		{
			if (Vector2.DistanceSquared(circle1.Center, circle2.Center) <= (circle1.Radius + circle2.Radius))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool CircleRecatangleCollision(Circle circle, Rectangle rect)
		{
			Vector2 distance = new Vector2(Math.Abs(circle.Center.X - rect.Center.X),
										   Math.Abs(circle.Center.Y - rect.Center.Y));
			if (distance.X > (rect.Width / 2 + circle.Radius)) return false;
			if (distance.Y > (rect.Height / 2 + circle.Radius)) return false;

			if (distance.X <= rect.Width / 2) return true;
			if (distance.Y <= rect.Height / 2) return true;

			float corner = (distance.X - rect.Width / 2) * (distance.X - rect.Width / 2) + (distance.Y - rect.Height / 2) * (distance.Y - rect.Height / 2);
			return (corner <= circle.Radius * circle.Radius);
		}

	}
}
