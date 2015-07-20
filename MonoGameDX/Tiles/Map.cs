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
        TileAbstract[,] tiles;
        public int Height { get; set; }
        public int Width { get; set; }
        public static int SIZE = 16;
        public static int SIZE_MULTIPLIER = 2;
        Texture2D grass;
        int count = 1;
        Random rand = new Random();

        private List<Wind> windArray = new List<Wind>();
        public Map(int height, int width)
        {
            Height = height;
            Width = width;
            tiles = new GrassTile[Width, Height];
            CreateWind();
        }
        public Map(int height, int width, Texture2D grass)
        {
            Height = height;
            Width = width;
            this.grass = grass;
            tiles = new GrassTile[Width, Height];
            CreateWind();
        }
        public void Initialize()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tiles[x, y] = new GrassTile(new Sprite(grass, 1, 12), new Vector2(x * SIZE * SIZE_MULTIPLIER, y * SIZE * SIZE_MULTIPLIER));
                }
            }
            //parse out dataSheet into tiles
        }
        public void CreateWind()
        {
            Vector2 point1 = new Vector2(200, 100);
            Vector2 point2 = new Vector2(100, 400);
            Wind wind = new Wind(point1, point2, SIZE * SIZE_MULTIPLIER, 0);
            windArray.Add(wind);
        }
        public void Update()
        {
            if (count % 100 == 0)
            {
                CreateWind();
            }
            count++;
            UpdateWind();

            UpdateTiles();
        }

        private void UpdateTiles()
        {
            //used to update the tiles here
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tiles[x, y].Update();
                }
            }
        }

        private void UpdateWind()
        {
            
            //used to update the windArray here
            //can't be in list form because wind can be removed durring foreachloop
            foreach (var wind in windArray.ToArray())
            {
                if (wind.IsWindDone)
                {
                    windArray.Remove(wind);
                }
                else
                {
                    IsTileInWind(wind);
                    wind.Update();
                }
            }
        }
        private void IsTileInWind(Wind wind)
        {
            Vector3[] windLocation = wind.GetWindLocation();

            int xStart = (int)windLocation[0].X / SIZE / SIZE_MULTIPLIER;
            int xEnd = (int)windLocation[windLocation.Length - 1].X / SIZE / SIZE_MULTIPLIER;
            int yStart = (int)windLocation[0].Y / SIZE / SIZE_MULTIPLIER;
            int yEnd = (int)windLocation[windLocation.Length - 1].Y / SIZE / SIZE_MULTIPLIER;

            if (xStart > xEnd)
            {
                int temp;
                temp = xStart;
                xStart = xEnd;
                xEnd = temp;
            }

            if (yStart > yEnd)
            {
                int temp;
                temp = yStart;
                yStart = yEnd;
                yEnd = temp;
            }

            if (yStart < 0) { yStart = 0; }
            if (xStart < 0) { xStart = 0; }
            if (yEnd >= tiles.GetLength(1)) { yEnd = tiles.GetLength(1) - 1; }
            if (xEnd >= tiles.GetLength(0)) { xEnd = tiles.GetLength(0) - 1; }

            for (int x = xStart; x <= xEnd; x++)
            {
                for (int y = yStart; y <= yEnd; y++)
                {
                    tiles[x, y].IsHitByWind(windLocation);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tiles[x, y].Draw(spriteBatch);
                }
            }

            foreach (var wind in windArray)
            {
                wind.Draw(spriteBatch);
            }

        }
    }
}
