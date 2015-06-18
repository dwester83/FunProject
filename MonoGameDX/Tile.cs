﻿using Microsoft.Xna.Framework;
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
        public AbstractSprite sprite { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 Center 
        {
            get { return new Vector2(Height/2, Width/2) ;}
        }
        public float Height { get; set; }
        public float Width { get; set; }
        public object CollisionObject { get; set; }
        public bool isSolid { get; set; }
        public bool isMoveable { get; set; }

        public Tile()
        {

        }
        public void Initialize()
        {

        }

        public void update()
        {

        }

        public void draw(SpriteBatch spritebatch)
        {

        }

    }
}
