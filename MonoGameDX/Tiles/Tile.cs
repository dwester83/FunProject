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
        public Tag TileType { get; set; }
        public bool IsSolid { get; set; }
        public bool isMoveable { get; set; }


        public Tile(Vector2 location, Type tileType)
        {
            Height = 32;
            Width = 32;
            TileType.Name = tileType;

        }


        public Tile(Vector2 location, float height, float width, Type tileType)
        {
            Height = height;
            Width = width;
            TileType.Name = tileType;
            
        }
        public void Initialize()
        {
            
            switch (TileType.Name)
            {
                case Type.Trees:
                    IsSolid = true;
                    isMoveable = false;
                    //load tree sprite here
                    break;
                case Type.Grass:
                    IsSolid = false;
                    isMoveable = false;
                    //load grass sprite here
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch, Location);
        }

    }
}
