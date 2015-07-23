using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX.Tiles
{
    public abstract class TileAbstract
    {
        #region public properties
        public Sprite TileSprite { get; set; }
        protected Vector2 Location { get; set; }
        public Vector2 Center
        {
            get { return new Vector2(Location.X + (Width / 2), Location.Y + (Height / 2)); }
        }
        public float Height { get; set; }
        public float Width { get; set; }
        public bool IsSolid { get; set; }
        public bool isMoveable { get; set; }
        #endregion

        #region abstract methods
        public abstract void Initialize();
        public abstract void Update();
        public abstract bool IsHitByWind(Vector3[] points);
        public abstract void Draw(SpriteBatch spritebatch);
        #endregion

        #region public methods

        public bool IsPointInTile(Vector3 point)
        {
            bool pointInTile = false;
            float rightX = Location.X + Width;
            float leftX = Location.X;
            float topY = Location.Y;
            float bottomY = Location.Y + Height;

            if(point.X <= rightX && point.X >= leftX && point.Y <= bottomY && point.Y >= topY)
            {
                
                pointInTile = true;
            }

            return pointInTile;
        }

        #endregion
    }
}
