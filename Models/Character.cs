using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UkuPacha.Managers;

namespace UkuPacha.Models
{
    public class Character
    {
        private static Texture2D standingTexture, forwardTexture, backwardsTexture;
        private readonly Animation standingAnim, forwardAnim, backwardsAnim;
        private Vector2 position;
        private readonly float speed = 200f;

        public Character(Vector2 position)
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


            this.position = position;
        }

        public void Update()
        {
            if (InputManager.Moving)
            {
                position += Vector2.Normalize(InputManager.Direction) * speed * Globals.TimeSinceLastUpdate;
                if(InputManager.Forward)
                    forwardAnim.Update();
                if(InputManager.Backwards) 
                    backwardsAnim.Update();
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
                    forwardAnim.Draw(position);
                if (InputManager.Backwards)
                    backwardsAnim.Draw(position);
            }
            else
            {
                standingAnim.Draw(position);
            }
        }
    }
}