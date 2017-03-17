using System;
using Microsoft.Xna.Framework;

namespace MG
{
	public class Circle
	{
		public float Radius { get; set; }
		public Vector2 Center { get; set; }

		public Circle(Vector2 center, float radius)
		{
			this.Center = center;
			this.Radius = radius;
		}
	}
}
