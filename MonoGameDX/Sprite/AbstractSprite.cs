using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX
{
    public abstract class AbstractSprite
    {
        public abstract void Initialize();
        public abstract void update();
        public abstract void draw(SpriteBatch spriteBatch);
    }
}
