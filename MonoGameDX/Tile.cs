using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX
{
    public class Tile
    {
        public Sprite sprite { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 Center 
        {
            get { return new Vector2(Location.X + (Width/2), Location.Y + (Height/2)) ; }
        }
        public float Height { get; set; }
        public float Width { get; set; }
        public BoundingBox CollisionObject { get; set; }
        public Tag Type { get; set; }
        public bool isSolid { get; set; }
        public bool isMoveable { get; set; }

        public Tile(Vector2 location)
        {

        }
        public void Initialize()
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch, Location);
        }

    }
}
