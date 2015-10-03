using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game_DX.Input
{
    interface IInputSubscriber
    {
        void NotifyOfChange(KeyboardChangeState keyboardChangeState, GameTime gameTime);
    }
}
