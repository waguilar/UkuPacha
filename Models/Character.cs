using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Content;
using UkuPacha.Managers;

namespace UkuPacha.Models
{
    public class Character : Sprite
    {
        private Vector2 minPosition, maxPosition;
        private readonly float speed = 200f;

        private AnimatedSprite _motwSprite;
        private Vector2 _motwPosition;

        public Character(Vector2 position) : base(position) 
        {
            //Standing
            var spritesheet = Globals.Content.Load<SpriteSheet>("char_a_p1_0bas_humn_v01.sf", new JsonContentLoader());
            var sprite = new AnimatedSprite(spritesheet);
            sprite.Play("walk_down");
            _motwPosition = position;
            _motwSprite = sprite;

            Position = position;
            //Origin = new Vector2(standingAnim.FrameWidth / 2, standingAnim.FrameHeight / 2);
        }

        public void SetBounds(Point mapSize, Point tileSize)
        {
            //minPosition = new Vector2((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
            //maxPosition = new Vector2(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y);
            minPosition = new Vector2((-tileSize.X / 2), (-tileSize.Y / 2));
            maxPosition = new Vector2(mapSize.X - (tileSize.X / 2), mapSize.Y - (tileSize.Y / 2));
        }

        string animation = "walk_down";
        public void Update()
        {
            if (InputManager.Moving)
            {
                Position += Vector2.Normalize(InputManager.Direction) * speed * Globals.TimeSinceLastUpdate;
                Position = Vector2.Clamp(Position, minPosition, maxPosition);
                if (InputManager.Forward)
                {
                    animation = "walk_right";
                }
                if(InputManager.Backwards)
                {
                    animation = "walk_left";
                }
                if(InputManager.Upwards)
                {
                    animation = "walk_up";
                }
                if (InputManager.Downwards)
                {
                    animation = "walk_down";
                }

                _motwSprite.Play(animation);
                _motwSprite.Update(Globals.TimeSinceLastUpdate);
            }
            else
            {
            }
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(_motwSprite, Position);
        }
    }
}