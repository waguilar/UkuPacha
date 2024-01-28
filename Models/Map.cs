using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace UkuPacha.Models
{
    public class Map
    {
        private readonly Point mapTileSize = new Point(4, 3);
        private readonly Sprite[,] tiles;
        public Point TileSize { get; private set; }
        public Point MapSize { get; private set; }

        public Map()
        {
            tiles = new Sprite[mapTileSize.X, mapTileSize.Y];
            var textures = new List<Texture2D>();
            for (int i = 1; i < 6; i++)
                textures.Add(Globals.Content.Load<Texture2D>($"tile{i}"));

            TileSize = new Point(textures[0].Width, textures[0].Height);
            MapSize = new(TileSize.X * mapTileSize.X, TileSize.Y * mapTileSize.Y);

            var random = new Random();

            for (int y = 0; y < mapTileSize.Y; y++)
            {
                for (int x = 0; x < mapTileSize.X; x++)
                {
                    int r = random.Next(0, textures.Count);
                    tiles[x, y] = new Sprite(textures[r], new(x * TileSize.X, y * TileSize.Y));
                }
            }
        }
        public void Draw()
        {
            for (int y = 0; y < mapTileSize.Y; y++)
            {
                for (int x = 0; x < mapTileSize.X; x++)
                {
                    tiles[x, y].Draw();
                }
            }
        }
    }
}
