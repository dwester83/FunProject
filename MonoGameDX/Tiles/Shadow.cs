using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX.Tiles
{
    class Shadow
    {
        public double X 
        { 
            get 
            { 
                //need to get total width of screen and work out an algorithm
                int position  = DateTime.Now.Minute;
                position = (position * 3) % 90;

                return position;
            } 
        }
        public double Y { get; set; }
        public int Height { get; set; }

        public Shadow(int height)
        {
            Height = height;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
