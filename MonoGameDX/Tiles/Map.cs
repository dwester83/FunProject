using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX.Tiles
{
    class Map
    {
        Sprite[,] tiles;
        public int Height { get; set; }
        public int Width { get; set; }
        public int size = 16;
        Texture2D grass;
        Random rand = new Random();
        int widthCount = 0;
        int heightCount = 0;
        bool widthup = true;
        bool heightup = true;
        public Map(int height, int width)
        {
            Height = height;
            Width = width;
            tiles = new Sprite[Width, Height];
        }
        public Map(int height, int width, Texture2D grass)
        {
            Height = height;
            Width = width;
            this.grass = grass;
            tiles = new Sprite[Width, Height];
        }
        public void Initialize()
        {

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tiles[x, y] = new Sprite(grass, 1, 18);
                }
            }
            //parse out dataSheet into tiles
        }

        public void Update()
        {
            if (widthup)
            {
                widthCount++;
            }
            else
            {
                widthCount--;
            }

            if (heightup)
            {
                heightCount++;
            }
            else
            {
                heightCount--;
            }

            if (widthCount >= Width || widthCount <= 0) { widthup = !widthup; }
            if (heightCount >= Height || heightCount <= 0) { heightup = !heightup; }
            for (int x = widthCount; x < Width; x++)
            {
                for (int y = heightCount; y < Height; y++)
                {
                    tiles[x, y].Update();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tiles[x, y].Draw(spriteBatch, new Vector2(x * size* 1, y * size * 1), 1);
                }
            }


        }
    }
}
