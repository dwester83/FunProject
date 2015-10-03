using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Game_DX.Input
{
    class KeyboardChangeState
    {
        public KeyboardState PreviousState { get; private set; }
        public KeyboardState CurrentState { get; private set; }

        public void SetState(KeyboardState keyboardState)
        {
            PreviousState = CurrentState;
            CurrentState = keyboardState;
        }

        public bool HasChanged()
        {
            if (PreviousState.Equals(CurrentState))
            {
                return true;
            }
            return false;
        }
    }
}
