using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_DX
{
    public class Tag
    {
        public Type TagType { get; set; }

        public Tag(Type tagType)
        {
            TagType = tagType;
        }
    }

    public enum Type
    {
        Trees,
        Grass
    }

}
