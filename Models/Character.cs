using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UkuPacha.Managers;

namespace UkuPacha.Models
{
    public class Character : Sprite
    {
        private static Texture2D standingTexture, forwardTexture, backwardsTexture;
        private readonly Animation standingAnim, forwardAnim, backwardsAnim;
        private Vector2 minPosition, maxPosition;
        private readonly float speed = 200f;

        public Character(Vector2 position) : base(position) 
        {
            //Standing
            standingTexture ??= Globals.Content.Load<Texture2D>("ryu_standing");
            standingAnim = new Animation(standingTexture, 10, 0.08f);

            //Forward
            forwardTexture ??= Globals.Content.Load<Texture2D>("ryu_forward");
            forwardAnim = new Animation(forwardTexture, 11, 0.08f);

            //Backwards
            backwardsTexture ??= Globals.Content.Load<Texture2D>("ryu_backward");
            backwardsAnim = new Animation(backwardsTexture, 11, 0.08f);

            Position = position;
            Origin = new Vector2(standingAnim.FrameWidth / 2, standingAnim.FrameHeight / 2);
        }

        public void SetBounds(Point mapSize, Point tileSize)
        {
            //minPosition = new Vector2((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
            //maxPosition = new Vector2(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y);
            minPosition = new Vector2((-tileSize.X / 2), (-tileSize.Y / 2));
            maxPosition = new Vector2(mapSize.X - (tileSize.X / 2) - standingAnim.FrameWidth, mapSize.Y - (tileSize.Y / 2) - standingAnim.FrameHeight);
        }

        public void Update()
        {
            if (InputManager.Moving)
            {
                Position += Vector2.Normalize(InputManager.Direction) * speed * Globals.TimeSinceLastUpdate;
                Position = Vector2.Clamp(Position, minPosition, maxPosition);
                if (InputManager.Forward)
                {
                    forwardAnim.Update();
                }
                if(InputManager.Backwards)
                {
                    backwardsAnim.Update();
                }
                    
            }
            else
            {
                standingAnim.Update();
            }
        }

        public void Draw()
        {
            if (InputManager.Moving)
            {
                if (InputManager.Forward)
                    forwardAnim.Draw(Position);
                if (InputManager.Backwards)
                    backwardsAnim.Draw(Position);
            }
            else
            {
                standingAnim.Draw(Position);
            }
        }
    }
}