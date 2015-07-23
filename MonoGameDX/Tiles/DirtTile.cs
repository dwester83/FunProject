using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX.Tiles
{
    class DirtTile: TileAbstract
    {
        public DirtTile(Sprite sprite, Vector2 location)
        {
            TileSprite = sprite;
            this.Location = location;
            Width = Map.SIZE * Map.SIZE_MULTIPLIER;
            Height = Map.SIZE * Map.SIZE_MULTIPLIER;
        }
        public override void Initialize()
        {
        }

        public override void Update()
        {
        }

        public override bool IsHitByWind(Vector3[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (IsPointInTile(points[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
             TileSprite.Draw(spritebatch, Location, Map.SIZE_MULTIPLIER);
        }
    }
}
