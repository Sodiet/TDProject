using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MG
{
    public class Map
    {
        Texture2D background { get; set; }
        Vector2 Position { get; set; }
        Point Size { get; set; }
        Vector2 Margins { get; set; }

        public Map(Vector2 position, Point size, Texture2D texture)
        {
            background = texture;
            Position = position;
            Size = size;
            Margins = new Vector2(-500, -100);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle((int)Position.X, (int)Position.Y, Size.X, Size.Y), Color.White);
        }

        internal void Update(Vector2 position, GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position = new Vector2(Position.X + (position.X - Position.X - Margins.X) * 2 * delta, 
                Position.Y + (position.Y - Position.Y - Margins.Y) * 5 * delta);
        }
    }
}
