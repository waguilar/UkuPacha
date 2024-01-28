using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UkuPacha.Models
{
    public class Sprite
    {
        private readonly Texture2D texture;
        public Vector2 Position { get; protected set; }
        public Vector2 Origin { get; protected set; }

        public Sprite(Vector2 position)
        {
            Position = position;
        }

        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            Position = position;
            Origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
