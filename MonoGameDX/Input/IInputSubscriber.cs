using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX.Input
{
    interface IInputSubscriber
    {
        void NotifyOfChange(KeyboardChangeState keyboardChangeState);
    }
}
