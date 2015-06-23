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
        List<Tile> tiles = new List<Tile>();
        public int Height { get; set; }
        public int Width { get; set; }

        public Map(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public void Initialize(string path)
        {
            //parse out dataSheet into tiles
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
