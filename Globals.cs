using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace UkuPacha
{
    public class Globals
    {
        public static float TimeSinceLastUpdate { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }

        public static void Update(GameTime gt)
        {
            TimeSinceLastUpdate = (float)gt.ElapsedGameTime.TotalSeconds;
        }
    }
}