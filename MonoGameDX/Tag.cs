using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_DX
{
    public class Tag
    {
        public Type Tag
        {
            set { Tag = value; }
            get { return Tag; }
        }
    }

    public enum Type
    {
        Trees,
        Grass
    }

}
