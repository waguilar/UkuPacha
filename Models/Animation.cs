using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace UkuPacha.Models
{
    public class Animation : BaseAnimation
    {
        private readonly Texture2D texture;
        private readonly List<Rectangle> sourceRectangles = new();
        private readonly int totalFrames;
        private int currentFrame;
        private readonly float frameTime;
        private float frameTimeLeft;

        public Animation(Texture2D texture, int framesx, float frameTime)
        {
            this.texture = texture;
            this.frameTime = frameTime;
            frameTimeLeft = this.frameTime;
            totalFrames = framesx;

            var frameWidth = texture.Width / framesx;
            var frameHeight = texture.Height;

            for (int i = 0; i < totalFrames; i++)
            {
                sourceRectangles.Add(new(i * frameWidth, 0, frameWidth, frameHeight));
            }
        }

        override public void Reset()
        {
            currentFrame = 0;
            frameTimeLeft = frameTime;
        }

        override public void Update()
        {
            if (!active) return;
            frameTimeLeft -= Globals.TimeSinceLastUpdate;
            if (frameTimeLeft <= 0)
            {
                frameTimeLeft += frameTime;
                currentFrame = (currentFrame + 1) % totalFrames;
            }
        }

        override public void Draw(Vector2 pos)
        {
            Globals.SpriteBatch.Draw(texture, pos, sourceRectangles[currentFrame], Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
        }
    }
}