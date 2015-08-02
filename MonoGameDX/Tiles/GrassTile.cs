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
    public class GrassTile: TileAbstract, IDisposable
    {
        Shadow shadow;
        private bool IsAnimating { get; set; }
        private int TotalFrames { get; set; }
        private int CurrentFrame { get; set; }
        private int count = 0;
        //TODO:: need to enbed sprite in tiles somehow
        //instead of p[assing it in
        static Random rand = new Random();
        public GrassTile(Sprite sprite, Vector2 location)
        {
            TileSprite = sprite;
            this.Location = location;
            TotalFrames = sprite.Columns * sprite.Rows;
            CurrentFrame = 0;
            IsAnimating = false;
            Width = Map.SIZE * Map.SIZE_MULTIPLIER;
            Height = Map.SIZE * Map.SIZE_MULTIPLIER;
            shadow = new Shadow(10, Location, sprite.Texture.Width, sprite.Texture.Height);
        }

        public override void Initialize()
        {
        }

        public override void Update()
        {
            shadow.Update();
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
            shadow.Draw(spritebatch);
            //TileSprite.Draw(spritebatch, Location, Map.SIZE_MULTIPLIER);
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

        #region IDisposable

        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this); // Only call this if you set EVERYTHING in this object to disposed and null.
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't 
        // own unmanaged resources itself, but leave the other methods
        // exactly as they are. 
        //~GrassTile()
        //{
        //    // Finalizer calls Dispose(false)
        //    Dispose(false);
        //}

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (shadow != null)
                {
                    shadow.Dispose();
                    shadow = null;
                }
            }

            // free native resources if there are any.
            //if (nativeResource != IntPtr.Zero)
            //{
            //    Marshal.FreeHGlobal(nativeResource);
            //    nativeResource = IntPtr.Zero;
            //}
        }

        #endregion
    }
}
