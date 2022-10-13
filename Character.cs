using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UkuPacha
{
    public class Character
    {
        private static Texture2D _texture;
        private Vector2 _position;
        private readonly Animation _anim;

        public Character(Vector2 pos)
        {
            _texture ??= Globals.Content.Load<Texture2D>("ryu_standing");
            _anim = new Animation(_texture, 10, 0.08f); 
            _position = pos;
        } 

        public void Update()
        {
            _anim.Update();
        }

        public void Draw()
        {
            _anim.Draw(_position);
        }
    }
}
