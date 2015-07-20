using Game_DX.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX
{
    public class GrassTile: TileAbstract
    {

        private bool IsAnimating { get; set; }
        private int TotalFrames { get; set; }
        private int CurrentFrame { get; set; }
        private int count = 0;
        //TODO:: need to enbed sprite in tiles somehow
        //instead of p[assing it in
        static Random rand = new Random();
        public GrassTile(Sprite sprite, Vector2 location) : base()
        {
            TileSprite = sprite;
            this.Location = location;
            TotalFrames = sprite.Columns * sprite.Rows;
            CurrentFrame = 0;
            IsAnimating = false;
            Width = Map.SIZE * Map.SIZE_MULTIPLIER;
            Height = Map.SIZE * Map.SIZE_MULTIPLIER;
        }

        public override void Initialize()
        {
        }

        public override void Update()
        {
            if (IsAnimating)
            {
                if(count % (rand.Next(1) + 4) == 0)
                {
                    TileSprite.Update();
                    CurrentFrame++;
                }

                count++;
            }

            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
                count = 0;
                IsAnimating = false;
            }
            
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            TileSprite.Draw(spritebatch, Location, Map.SIZE_MULTIPLIER);
        }

        public override bool IsHitByWind(Vector3[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {

                if (IsPointInTile(points[i]))
                {
                    IsAnimating = true;
                    return true;
                }
            }
            return false;
        }
    }
}
