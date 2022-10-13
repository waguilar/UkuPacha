using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UkuPacha.Managers;

namespace UkuPacha.Models
{
    public class Character
    {
        private static Texture2D _texture;
        private Vector2 _position;
        private readonly float _speed = 200f;
        private readonly Animation _anim;

        public Character(Vector2 pos)
        {
            _texture ??= Globals.Content.Load<Texture2D>("ryu_standing");
            _anim = new Animation(_texture, 10, 0.08f);
            _position = pos;
        }

        public void Update()
        {
            //if (InputManager.Moving)
            //{
            //    _position += Vector2.Normalize(InputManager.Direction) * _speed * Globals.TotalSeconds;
            //}
            _anim.Update();
        }

        public void Draw()
        {
            _anim.Draw(_position);
        }
    }
}