using Microsoft.Xna.Framework;
using System;
using System.Data;
using UkuPacha.Models;

namespace UkuPacha.Managers
{
    public class GameManager
    {
        Map map;
        Character character;
        private Matrix translation;

        public void Init()
        {
            map = new Map();
            character = new Character(new Vector2(300, 300));
            character.SetBounds(map.MapSize, map.TileSize);
        }

        public void Update()
        {
            InputManager.Update();
            character.Update();
            CalculateTranslation();
        }

        private void CalculateTranslation()
        {
            var dx = (Globals.WindowSize.X / 2) - character.Position.X;
            //dx = MathHelper.Clamp(dx, - map.MapSize.X + Globals.WindowSize.X + ( map.TileSize.X / 2), map.TileSize.X / 2);
            var dy = (Globals.WindowSize.Y / 2) - character.Position.Y;
            //dy = MathHelper.Clamp(dy, - map.MapSize.Y + Globals.WindowSize.Y + ( map.TileSize.Y / 2), map.TileSize.Y / 2);
            translation = Matrix.CreateTranslation(dx, dy, 0f);
        }


        public void Draw()
        {
            Globals.SpriteBatch.Begin(transformMatrix: translation);
            map.Draw();
            character.Draw();
            Globals.SpriteBatch.End();
        }
    }
}